using ChronoPlus.Controller;
using ChronoPlus.Core.Abstraction;

namespace ChronoPlus.Console
{
    public class ChronoControl : ChronoController
    {
        protected override void Configure(IChronoConnectionSettings settings)
        {
            settings.AuthenticationKey =
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Im5pc2h0b2RydWdvQGdtYWlsLmNvbSIsImlkIjoianVnYW5kIiwidWlkIjoiNWIyNTU1MDVlOGQ5MWIwMDExNzY5ZDg4IiwiaWF0IjoxNTU3MTI1NjcyLCJleHAiOjE1NjIzMDk2NzIsImF1ZCI6Imh0dHBzOi8vd3d3LmNocm9uby5nZyIsImlzcyI6Imh0dHBzOi8vYXBpLmNocm9uby5nZyIsImp0aSI6ImVmNjE0NzczYTVlMjRhY2VhYmE3ZTFmNmQxNDlmNzVlIn0.8O2PlgZLsID0WTpCQg_76kwWqC-uxo4trz_2s_Pa2Io";
        }
    }
}