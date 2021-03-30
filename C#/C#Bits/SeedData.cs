using JobBoardMVC.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using JobBoardMVC.Models;

namespace JobBoardMVC.DAL
{
    public class SeedData
    {

        public static void InitializeDb(JobBoardMvcContext context)
        {
            if (context.Job.Any())
            {
                return;
            }
            else {

                var jobsJsonAll = GetEmbeddedResourceAsString("JobBoardMVC.App_Data.Amazon.json"); 
                
                   

                JArray jsonValJobs = JArray.Parse(jobsJsonAll) as JArray;
                dynamic jobsData = jsonValJobs;
                foreach (dynamic job in jobsData)
                {
                    context.Job.Add(new Job
                    {
                        ApplicationLink = job.ApplicationLink,
                        Company = job.Company,
                        DatePosted = job.DatePosted,
                        Experience = job.Experience,
                        Hours = job.Hours,
                        JobID = job.JobId,
                        JobTitle = job.JobTitle,
                        LanguagesUsed = job.LanguagesUsed,
                        Location = job.Location,
                        Salary = job.Salary

                     });
                }
            }
        }

        private static string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //var names = assembly.GetManifestResourceNames();

            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))

            using (StreamReader reader = new StreamReader(stream))
                   
            result = reader.ReadToEnd();
                   
            return result;

        }
    }
}



