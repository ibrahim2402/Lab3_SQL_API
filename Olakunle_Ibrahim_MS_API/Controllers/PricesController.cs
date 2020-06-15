using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olakunle_Ibrahim_MS_API.Models;

namespace Olakunle_Ibrahim_MS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {

/**
 * This is the API endpoint that calculate the ticket price of the selected choice by the user from the frontend.
 * The discount is based on percentage, depending on the number of passenger that want to travel. 
 * The API request is received and response JSON is sent back to the frontend. 
 * Note; This a standalone API endpoint because it not connected to the database but only used for price logic.
 *
 * All other entities controllers are connected to its various Azure SQL server (database table). 
 * They are generated with ASP.NET scaffolding framwork. It provides the pre-installed code for MVC and Web API project.
 * These controllers recieved API request call from the frontend application and return a corresponding response JSON for each request.
 * 
 * Its important to mention that the created ControllerNoSQL folder is to try out with connecting this framwork API generated with 
 * NOSQL database (Azure CosmosDB) with a little or no success and failure is not substantiated, 
 * the response code was authorization denied which i guess its an emulator or a security bridge.
 * I may continue to work on this appraoch because i believe it could work but for the purpose of this task here is the limitation.
 */
        private string[] airportCodes = { "STO", "CPH", "CDG", "LHR", "FRA" };
        private string[] airportNames = { "Stockholm", "Copenhagen", "Paris", "London", "Frankfurt" };
        private double[] latitudes = { 59.6519, 55.6181, 49.0097, 51.4707, 50.1167 };
        private double[] longitudes = { 17.9186, 12.6561, 2.5478, -0.4543, 8.6833 };

        private List<Price> amount = new List<Price>()
        {
            new Price{travel=200, car=300, total=400}
        };


        [HttpGet("{from}/{to}/{passenger}")]
        public double Get(string from, string to, string  passenger)
        {
            double dis = getFlightDistance(from, to);
            double pris= calculatedPrice(Int32.Parse(passenger), dis);

            return pris;

         /*   return new List<Price>()
        {
            new Price{travel=200, car=300, total=400}
        }; */

        }

        private double calculatedPrice(int passenger,  double distance)
        {
            double baseprice = 2500.0;
            double amount;

            if (passenger > 2)
            {
                amount = (baseprice * passenger) * 0.5;
            }
            else
            {
                amount = (baseprice * passenger) * 0.2;
            }


            return amount;
        }

        public double getFlightDistance(string origin, string destination)
        {
            double earthRadius = 6371.0;

            double latitudeFrom, longitudeFrom, latitudeTo, longitudeTo;
            latitudeFrom = getLatLongitude(origin, 'L');
            longitudeFrom = getLatLongitude(origin, 'G');
            latitudeTo = getLatLongitude(destination, 'L');
            longitudeTo = getLatLongitude(destination, 'G');
            if ((latitudeFrom < -999) || (longitudeFrom < -999) || (latitudeTo < -999) || (longitudeTo < -999)) return -1;
            //            if ((latitudeFrom < 0) || (longitudeFrom < 0) || (latitudeTo < 0) || (longitudeTo < 0))  return -1;

            double x1 = degreeToRadians(latitudeFrom);
            double y1 = degreeToRadians(longitudeFrom);
            double x2 = degreeToRadians(latitudeTo);
            double y2 = degreeToRadians(longitudeTo);
            // great circle distance in radians
            double centralAngle = Math.Acos(Math.Sin(x1) * Math.Sin(x2) + Math.Cos(x1) * Math.Cos(x2) * Math.Cos(y1 - y2));
            double distanceXY = earthRadius * centralAngle;
            return distanceXY;
        }

        private double degreeToRadians(double angleDegrees)
        {
            return (Math.PI / 180) * angleDegrees;
        }

        private double getLatLongitude(string s, char latorlong)
        {
            int i;
            for (i = 0; i < 5; i++)
            {
                if (s == airportCodes[i]) break;
            }
            if (i >= 5)
            {
                return (double)-1000.0;
            }
            else
            {
                if (latorlong == 'L') return latitudes[i];
                return longitudes[i];
            }
        }

    }
}