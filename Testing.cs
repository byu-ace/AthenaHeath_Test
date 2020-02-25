//    Copyright 2014 athenahealth, Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License"); you
//   may not use this file except in compliance with the License.  You
//   may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
//   implied.  See the License for the specific language governing
//   permissions and limitations under the License.

using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Threading;
using Athenahealth;
using System.IO;
using Newtonsoft.Json.Linq;
using AthenaHeath_Test;

public class Testing
{
    static public void Main()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Setup
        ////////////////////////////////////////////////////////////////////////////////////////////////
        string key = "vy2e2stx2ym4dvyagck7j36m";
        string secret = "5AfgfU6Q3cZGYRK";
        string version = "preview1";
        string practiceid = "195900";
        string jsonString = string.Empty;
        string path = null;

        AetheaProviderEntities AethenalealthProvider = new AetheaProviderEntities();

        APIConnection api = new APIConnection(version, key, secret, practiceid);

        // If you want to set the practice ID after construction, this is how.
        // api.PracticeID = "195900";


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // GET without parameters
        ////////////////////////////////////////////////////////////////////////////////////////////////
        JsonValue customfields = api.GET("/customfields");
        jsonString = customfields.ToString();
        path = "../../customfields.json";
        File.WriteAllText(path, jsonString);

        Console.WriteLine("Custom fields:");

        foreach (JsonValue field in customfields)
        {
            Console.WriteLine("\t" + field["name"]);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Get available practice IDs
        ////////////////////////////////////////////////////////////////////////////////////////////////

        //  https://api.athenahealth.com/preview1/1/practiceinfo?limit=20&offset=0

        Dictionary<string, string> search1 = new Dictionary<string, string>()
        {
            { "practiceid", "1"},
            { "limit", "20"},
            { "offset", "0"},
        };

        JsonValue practiceInfo = api.GET("/practiceinfo");
        jsonString = practiceInfo.ToString();
        path = "../../practiceInfo.json";
        File.WriteAllText(path, jsonString);

        //  Console.WriteLine("practice info:");
        // foreach (JsonValue field in practiceInfo)
        // {
        //     Console.WriteLine("\t" + field["name"]);
        // }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Get  Get department IDs
        ////////////////////////////////////////////////////////////////////////////////////////////////

        //  Dictionary<string, string> search2 = new Dictionary<string, string>()
        //  {
        //      { "practiceid", "1"},
        //      { "limit", "20"},
        //      { "offset", "0"},
        //  };

        //  JsonValue departments = api.GET("/departments");
        //  jsonString = departments.ToString();
        //  dynamic data = JObject.Parse(jsonString);
        //  string totalaccount = data.totalcount;
        //  JArray depts = (JArray)data.SelectToken("departments");
        //  foreach (JToken dep in depts)
        //  {

        //       string address = (string)dep.SelectToken("name");
        //       string chartsharinggroupid = (string)dep.SelectToken("name");
        //       string city = (string)dep.SelectToken("name");
        //       string clinicals = (string)dep.SelectToken("name");
        //       string communicatorbrandid = (string)dep.SelectToken("name");
        //       string creditcardtypes = (string)dep.SelectToken("name");
        //       string departmentid = (string)dep.SelectToken("name");
        //       string doesnotobservedst = (string)dep.SelectToken("name");
        //       string ecommercecreditcardtypes = (string)dep.SelectToken("name");
        //       string fax = (string)dep.SelectToken("name");
        //       string ishospitaldepartment = (string)dep.SelectToken("name");
        //       string latitude = (string)dep.SelectToken("name");
        //      "longitude": "-85.17026",
        //"medicationhistoryconsent": false,
        //"name": "MAIN ST (HUB)",
        //"oneyearcontractmax": "1500",
        //"patientdepartmentname": "Rome Office",
        //"phone": "(555) 916-7897",
        //"placeofservicefacility": false,
        //"placeofservicetypeid": "11",
        //"placeofservicetypename": "OFFICE",
        //"portalurl": "www.kenneth.net",
        //"providergroupid": "1",
        //"providergroupname": "Downtown Health Group",
        //"servicedepartment": true,
        //"singleappointmentcontractmax": "3000",
        //"state": "GA",
        //"timezone": -5,
        //"timezonename": "US/Eastern",
        //      string timezoneoffset = (string)dep.SelectToken("name");
        //      string zip = (string)dep.SelectToken("name");

        //  }




        //  path = "../../departments.json";
        //  File.WriteAllText(path, jsonString);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Get  Get providers
        ////////////////////////////////////////////////////////////////////////////////////////////////

        JsonValue providers = api.GET("/providers");
        jsonString = providers.ToString();
        dynamic data = JObject.Parse(jsonString);
        string totalprovideraccount = data.totalcount;
        JArray AethProvider = (JArray)data.SelectToken("providers");
        Boolean AcceptingnewPatients = false;
        string AnsinameCode = string.Empty;
        string AnsispecialtyCode = string.Empty;
        Boolean Billable = false;
        Boolean CreateenCounteronCheckin = false;
        string DisplayName = string.Empty;
        string FirstName = string.Empty;
        string LastName = string.Empty;
        string EntityType = string.Empty;
        string SupervisingProviderUserName = string.Empty;
        Boolean HideInPortal = false;
        string ProviderID = string.Empty;
        string ProviderType = string.Empty;
        string ProviderTypeId = string.Empty;
        string SchedulingName = string.Empty;
        string Specialty = string.Empty;
        int SupervisingProviderID = 0;
        string CreatedBy = "BoomiDbUser";

        using (AetheaProviderEntities db = new AetheaProviderEntities())
        {

         foreach (JToken pro in AethProvider)
         {

            //(string)dep.SelectToken("name");

            if (pro.SelectToken("acceptingnewpatients") != null)
            {
                   AcceptingnewPatients = System.Convert.ToBoolean(pro.SelectToken("acceptingnewpatients"));
            }
            if (pro.SelectToken("ansinamecode") != null)
            {
                    AnsinameCode = (string)pro.SelectToken("ansinamecode"); 
            }
            if (pro.SelectToken("ansispecialtycode") != null)
            {
                  AnsispecialtyCode = (string)pro.SelectToken("ansispecialtycode");
                }
            if (pro.SelectToken("billable") != null)
            {
                    Billable = System.Convert.ToBoolean(pro.SelectToken("billable"));
                }
            if (pro.SelectToken("createencounteroncheckin") != null)
            {
                    CreateenCounteronCheckin = System.Convert.ToBoolean(pro.SelectToken("createencounteroncheckin"));
                }
            if (pro.SelectToken("displayname") != null)
            {
                  DisplayName = (string)pro.SelectToken("displayname");
                }
            if (pro.SelectToken("entitytype") != null)
            {
                  EntityType = (string)pro.SelectToken("entitytype");
                }
            if (pro.SelectToken("firstname") != null)
            {
                   FirstName = (string)pro.SelectToken("firstname");
                } 
            if (pro.SelectToken("hideinportal") != null)
            {
                   HideInPortal = System.Convert.ToBoolean(pro.SelectToken("hideinportal"));
                }
            if (pro.SelectToken("lastname") != null)
            {
                  LastName = (string)pro.SelectToken("lastname");
                }
            if (pro.SelectToken("providerid")!= null)
            {
                 ProviderID = (string)pro.SelectToken("providerid");
                }
            if (pro.SelectToken("providertype") != null)
            {
                    ProviderType = (string)pro.SelectToken("providertype");
                }
            if (pro.SelectToken("providertypeid") != null)
            {
                   ProviderTypeId = (string)pro.SelectToken("providertypeid");
                }
            if (pro.SelectToken("schedulingname") != null)
            {
                   SchedulingName = (string)pro.SelectToken("schedulingname");
                }
            if (pro.SelectToken("specialty") != null)
            {
                   Specialty = (string)pro.SelectToken("specialty");
                }
            if (pro.SelectToken("supervisingproviderid") != null)
            {
                   SupervisingProviderID = (int)pro.SelectToken("supervisingproviderid");
                }
            if (pro.SelectToken("supervisingproviderusername") != null)
            {
                  SupervisingProviderUserName = (string)pro.SelectToken("supervisingproviderusername");
              }

                db.ImportAtheanProvider(AcceptingnewPatients,
                                            AnsinameCode,
                                            AnsispecialtyCode,
                                            Billable,
                                            CreateenCounteronCheckin,
                                            DisplayName,
                                            EntityType,
                                            FirstName,
                                            HideInPortal,
                                            LastName,
                                            ProviderID,
                                            ProviderType,
                                            ProviderTypeId,
                                            SchedulingName,
                                            Specialty,
                                            SupervisingProviderID,
                                            SupervisingProviderUserName,
                                            CreatedBy);

            }

            db.SaveChanges();
        }

     
        // JsonValue providers = api.GET("/providers ");
        jsonString = providers.ToString();
        path = "../../providers.json";
        File.WriteAllText(path, jsonString);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Get  Get providers
        ////////////////////////////////////////////////////////////////////////////////////////////////
        Dictionary<string, string> searchcommunicatorbrand = new Dictionary<string, string>()
        {
              { "communicatorbrandid", "2"}
           
          };


        JsonValue communicatorbrands = api.GET("/communicatorbrands", searchcommunicatorbrand);
        jsonString = communicatorbrands.ToString();
        path = "../../communicatorbrands.json";
        File.WriteAllText(path, jsonString);

       


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Get  communicatorbrands 
        ////////////////////////////////////////////////////////////////////////////////////////////////

      



        ////////////////////////////////////////////////////////////////////////////////////////////////
        // GET with parameters
        ////////////////////////////////////////////////////////////////////////////////////////////////
        string format = "MM/dd/yyyy";
        DateTime today = DateTime.Now;
        DateTime nextyear = today.AddYears(1);

        Dictionary<string, string> search = new Dictionary<string, string>()
          {
            {"departmentid", "1"},
            {"startdate", today.ToString(format)},
            {"enddate", nextyear.ToString(format)},
            {"appointmenttypeid", "2"},
            {"limit", "1"},
            { "ignoreschedulablepermission", "true"}
          };

        JsonValue open_appts = api.GET("/appointments/open", search);
        //JsonValue open_appts = api.GET("/appointments/open");
        Console.WriteLine(open_appts.ToString());
        JsonValue appt = open_appts["appointments"][0];
        Console.WriteLine("Open appointment:");
        Console.WriteLine(appt.ToString());

        Dictionary<string, string> newAppt = new Dictionary<string, string>();
        foreach (KeyValuePair<string, JsonValue> kvp in appt)
        {
            newAppt[kvp.Key] = kvp.Value.ToString();
        }


        // add keys to make appt usable for scheduling
        appt["appointmenttime"] = appt["starttime"];
        appt["appointmentdate"] = appt["date"];


        // Thread.Sleep(1000); 		// NOTE: Uncomment this line if you keep getting "Over QPS" errors
        ////////////////////////////////////////////////////////////////////////////////////////////////
        // POST with parameters
        ////////////////////////////////////////////////////////////////////////////////////////////////
        Dictionary<string, string> patientInfo = new Dictionary<string, string>()
	  {
		{"departmentid", "1"},
		{"lastname", "YOU"},
		{"firstname", "BING"},
		{"address1", "123 Any Street"},
		{"city", "Cambridge"},
		{"countrycode3166", "US"},
		{"dob", "6/18/1987"},
		{"language6392code", "declined"},
		{"maritalstatus", "S"},
		{"race", "declined"},
		{"sex", "M"},
		{"ssn", "123456789"},
		{"zip", "02139"},
	  };

	JsonValue newPatient = api.POST("/patients", patientInfo);
	Console.WriteLine(newPatient.ToString());
	string newPatientID = newPatient[0]["patientid"];
	Console.WriteLine("New patient id:");
	Console.WriteLine(newPatientID);
		

	//////////////////////////////////////////////////////////////////////////////////////////////////
	//// PUT with parameters
	//////////////////////////////////////////////////////////////////////////////////////////////////
	Dictionary<string, string> appointmentInfo = new Dictionary<string, string>()
	    {
		   {"appointmenttypeid", "82"},
		   {"departmentid", "1"},
		   {"patientid", newPatientID},
	    };

        JsonValue booked = api.PUT("/appointments/" + appt["appointmentid"], appointmentInfo);
        Console.WriteLine("Booked:");
        Console.WriteLine(booked.ToString());


        //// Thread.Sleep(1000); 		// NOTE: Uncomment this line if you keep getting "Over QPS" errors
        //////////////////////////////////////////////////////////////////////////////////////////////////
        //// POST without parameters
        ////////////////////////////////////////////////////////////////////////////////////////////////
        JsonValue checked_in = api.POST(string.Format("/appointments/{0}/checkin", appt["appointmentid"]));
        Console.WriteLine("Check-in:");
        Console.WriteLine(checked_in.ToString());


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // DELETE with parameters
        ////////////////////////////////////////////////////////////////////////////////////////////////
        Dictionary<string, string> deleteParams = new Dictionary<string, string>()
	  {
		{"departmentid", "1"},
	  };
	JsonValue chartAlert = api.DELETE(string.Format("/patients/{0}/chartalert", newPatientID), deleteParams);
	Console.WriteLine("Removed chart alert:");
	Console.WriteLine(chartAlert.ToString());
		
		
	////////////////////////////////////////////////////////////////////////////////////////////////
	// DELETE without parameters
	////////////////////////////////////////////////////////////////////////////////////////////////
	JsonValue photo = api.DELETE(string.Format("/patients/{0}/photo", newPatientID));
	Console.WriteLine("Removed photo:");
	Console.WriteLine(photo.ToString());
		
		
	////////////////////////////////////////////////////////////////////////////////////////////////
	// There are no PUTs without parameters
	////////////////////////////////////////////////////////////////////////////////////////////////
		
		
	// Thread.Sleep(1000); 		// NOTE: Uncomment this line if you keep getting "Over QPS" errors
	////////////////////////////////////////////////////////////////////////////////////////////////
	// Error conditions
	////////////////////////////////////////////////////////////////////////////////////////////////
	JsonValue badPath = api.GET("/nothing/at/this/path");
	Console.WriteLine("GET /nothing/at/this/path:");
	Console.WriteLine(badPath.ToString());
	JsonValue missingParameters = api.GET("/appointments/open");
	Console.WriteLine("Missing parameters:");
	Console.WriteLine(missingParameters.ToString());


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Testing token refresh
        //
        // NOTE: this test takes an hour, so it's disabled by default. Change false to true to run.
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ///	if (false) {
        if (true) { 
        string oldToken = api.GetToken();
	  Console.WriteLine("Old token: " + oldToken);
			
	  api.GET("/departments");
			
	  // Wait 3600 seconds = 1 hour for token to expire.
	  Thread.Sleep(3600 * 1000);
			
	  api.GET("/departments");
			
	  Console.WriteLine("New token: " + api.GetToken());
	}
  }
}

