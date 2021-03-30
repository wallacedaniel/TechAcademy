# Title: Scrape ActOn.com Portland Jobs
# Course: Live Project : Tech Academy Portland
# Author: Daniel Wallace
# Purpose: Prosper IT Job Board App for PortlandTech.Org.

# Notes:
# Possible improvements: Has to reach down into links to retrieve job information...Slow run

 #Main page...act-on.com/careers/listings/#Portland...Jobs listings return jobs from ALL locations
    #   ...targets contain "Portland" class which proved elusive.    
# Targeting Portland Location ?? text on...act-on.com/careers/listings/#Portland
    #...would eliminate need to go into links and speed things up considerably.
# jobs = soup.find_all('div', {"class":"col-md-6"})


# Import modules
import bs4 as bs
import urllib.request
import json

# Defines Source
sauce = urllib.request.urlopen('https://www.act-on.com/careers/listings/#Portland').read()

soup = bs.BeautifulSoup(sauce, 'lxml')

jobs = []

# Returns links to individual job at all locations
for url in soup.find_all('a'):
    if type(url.get('href')) == str:
        href = url.get('href')
        if href.find('/careers/details/?jobId') == False:
            link = 'https://www.act-on.com' + href
            
            # Defines new source within each link returned
            sauce = urllib.request.urlopen(link).read()
            soup = bs.BeautifulSoup(sauce, 'lxml')
            loc = soup.h2.next_sibling.next.next.next.next.text.strip('| ')
            loc = loc.strip(', United States')
            loc = loc.strip()

            # Removes non Portland locations
            if loc == 'Portland, OR':

                # Creates job dictionary
                job = {
                    "ApplicationLink": link,
                    "Company": "Act-On",
                    "DatePosted": "",
                    "Experience": "",
                    "Hours": "",
                    "JobID": "",
                    # Retrieves job title
                    "JobTitle": soup.h2.text,
                    "LanguageUsed": "",
                    "Location": loc,
                    "Salary": ""  
                }
                jobs.append(job)

# Writes out to json file..currently targets to desktop
job_list = json.dumps(jobs)

outfile = open('act_on_scrape.json', 'w')
outfile.write(job_list)
outfile.close()

                
            



