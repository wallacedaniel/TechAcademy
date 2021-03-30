# Title: Scrape Automattic Jobs
# Project: Prosper IT MVC JobBoard 
# Author: Daniel Wallace
# Purpose:  Scrape jobs information from Automattic.com and save out as JSON. 

# Notes: Portland is hard coded as the location for these jobs. They are all in reality remote work.
# Returns JSON file to same folder location as this script.

# Import modules
import bs4 as bs
import urllib.request
import json

# Defines Source
sauce = urllib.request.urlopen('https://automattic.com/work-with-us/').read()

soup = bs.BeautifulSoup(sauce, 'lxml')

jobs = []

jobs_div = soup.find('div', {"class":"joblistings"})

job_titles = jobs_div.find_all('li')

for job_title in job_titles:
    title = job_title.text
    link = job_title.next.get('href')


    # Creates job dictionary
    job = {
        "ApplicationLink": link,
        "Company": "Automattic",
        "DatePosted": "",
        "Experience": "",
        "Hours": "",
        "JobID": "",
        "JobTitle": title,
        "LanguageUsed": "",
        "Location": "Portland",
        "Salary": ""  
        }
    jobs.append(job)



# Writes out to json file
job_list = json.dumps(jobs)

outfile = open('automattic.json', 'w')
outfile.write(job_list)
outfile.close()	







                








                
            



