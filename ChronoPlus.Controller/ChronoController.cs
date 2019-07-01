using System;
using System.Net.Http;
using System.Threading.Tasks;
using ChronoPlus.Controller.Abstraction;
using ChronoPlus.Controller.Models;
using ChronoPlus.Core;
using ChronoPlus.Core.Abstraction;
using ChronoPlus.Core.Enums;

namespace ChronoPlus.Controller
{
    public abstract class ChronoController : IDisposable
    {
        private readonly HttpClient HttpClient = new HttpClient();
        private IChronoConnection _connection;
        private IChronoDeserializer _deserializer;
        private IChronoConnectionSettings _settings;

        /// <summary>
        ///     Defaults to Spin method. You can change it if you want to send different request.
        /// </summary>
        public ChronoMethod Method = ChronoMethod.Spin;

        /// <summary>
        ///     The result received from the last sent request. Defaults to Unknown.
        /// </summary>
        public Result ResponseResult = Result.Unknown;

        protected ChronoController(string authenticationKey)
        {
            this._deserializer = new ChronoDeserializer();
            this._connection = new ChronoConnection(HttpClient);
            this._settings = new ChronoConnectionSettings {AuthenticationKey = authenticationKey};
        }
        protected ChronoController(IChronoConnectionSettings settings)
        {
            this._deserializer = new ChronoDeserializer();
            this._connection = new ChronoConnection(HttpClient);
            this._settings = settings;
        }
        protected ChronoController()
        {
            this._deserializer = new ChronoDeserializer();
            this._connection = new ChronoConnection(HttpClient);
            this._settings = new ChronoConnectionSettings();
            Configure(this._settings);

            if (string.IsNullOrEmpty(this._settings.AuthenticationKey))
                throw new ArgumentException(
                    "ChronoConnectionSettings does not contain authentication key. Please check the 'Configure' method and make sure you have provided authentication key.");
        }

        /// <summary>
        ///     Contains all the information from successful received response.
        /// </summary>
        public ChronoHttpContext HttpContext { get; private set; }

        /// <summary>
        ///     Configuration method for the default connection.
        /// </summary>
        /// <param name="settings">Throws exception if authentication key is not provided.</param>
        protected abstract void Configure(IChronoConnectionSettings settings);

        /// <summary>
        ///     Sends new Spin request with Spin's default settings.
        ///     Returns model with the response.
        /// </summary>
        public ChronoCoinInformationModel SpinCoin()
        {
            this.Method = ChronoMethod.Spin;
            this._settings.PrepareWithDefaultSettings(ChronoMethod.Spin);
            SendRequest();
            return (ChronoCoinInformationModel) this.HttpContext.Model;
        }

        /// <summary>
        ///     Sends new Check request with Check's default settings.
        /// </summary>
        public ChronoCheckInformationModel CheckUser()
        {
            this.Method = ChronoMethod.Check;
            this._settings.PrepareWithDefaultSettings(ChronoMethod.Check);
            SendRequest();
            return (ChronoCheckInformationModel) this.HttpContext.Model;
        }

        /// <summary>
        ///     Sends new request with current Method's default settings.
        /// </summary>
        public void SendDefaultRequest()
        {
            this._settings.PrepareWithDefaultSettings(this.Method);
            SendRequest();
        }

        /// <summary>
        ///     Sends request with the provided settings in the configuration. This method does not
        ///     use default Chrono settings, it will send default http request if no new headers are
        ///     defined in the settings.
        /// </summary>
        public void SendRequest()
        {
            this._connection.SendInformRequest(this._settings);
            var response = this._connection.SendHttpRequest(this._settings);

            this.HttpContext = this._deserializer.DeserializeResponse(response, this.Method);
            InterpretResult();
        }

        public async Task SendRequestAsync()
        {
            await this._connection.SendInformRequestAsync(this._settings);
            var response = await this._connection.SendHttpRequestAsync(this._settings);

            this.HttpContext = this._deserializer.DeserializeResponse(response, this.Method);
            InterpretResult();
        }

        private void InterpretResult()
        {
            Enum.TryParse(((int)this.HttpContext.Response.StatusCode).ToString(), out this.ResponseResult);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.HttpClient?.Dispose();
                this.HttpContext?.Dispose();
                this._settings = null;
                this._connection = null;
                this._deserializer = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ChronoController()
        {
            Dispose(false);
        }
    }
}