<p align="center">
  <h3 align="center">Chrono+</h3>
  <p align="center">
    Simple lightweight request-response oriented agent for Chrono.gg API.
	Currently in early alpha stage, providing only windows .net framework support.
    <br />
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Contents
[![Build Status](https://travis-ci.com/JuganD/ChronoPlus.svg?token=ytDmLhFdCaPPDKBEsY1o&branch=master)](https://travis-ci.com/JuganD/ChronoPlus)
* [About the Project](#about-the-project)



<!-- ABOUT THE PROJECT -->
## About The Project

ChronoPlus is timed voting and user information checking application for the website Chrono.gg. 

The application is using every user individual account cookie and sending GET and POST requests toward the Chrono website, as any browser does.
The main goal of the windows application (ChronoPlus.Lightweight.Windows) is to be high-performance and lightweight application, not extensibility or ease of use of the code.
That being said, I'm aiming for best code readability, where possible, and of course as best as possible UI usability.
In order to process the requests to Chrono API, it is required that the user provides JSON Web Token (JWT) for Chrono.gg website ONLY!
The JWT key can be acquired by typing `localStorage.getItem('jwt')` in the browser console, while you are in Chrono.gg website and successfully logged in.

## This application is not tool for malevolent actions as it is performing the same actions as entering the website from any browsing software.