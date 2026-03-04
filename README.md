# TSD Full Stack CMS Technical Assessment

A Short technical assessment to test out ones ability to create a basic umbraco site with data driven from an API

## The Ask

We want you to take this shell solution, that consists of an empty Umbraco 17 site, that has SaSS pre configured and a .net 10 web api, and create a basic output for the products supplied in the included products.json file in the /data directory of the API project.

This should use modern Umbraco and .NET best practises to output the data in a re-usable format of your choosing, that makes sense for the context of the data given.

The data should come from the API, which internally reads the products.json file as a stubbed "database call". How you implement the API is up to you.

There is also a media.zip file included in the base of the solution, that contains stock imagery that corresponds to the products should you need it.

Ideally, the content output from the umbraco site should be done in such a way that it is easy to configure for a non technical user in the CMS, should they decide they wanted to view the data on a different page
or area of the site.

## Notes

- Take a fork of the repository to work on the assessment and email a link to your fork of the finished assessment back to us for review with any notes or supporting imagery. 

Ideally, this assessment should not take more than 2 hours to complete.

### Getting Started

- Run `npm install` to install the required node packages from the WWW prroject root
- Run `npm run sass` to compile Sass once
- Run `npm run sass:watch`to watch and auto-compile on changes

Compiled css will be output in wwwroot/css for you to consume

If you are using Rider as your IDE, you should be able to run both the API and CMS using the "Run All" compound build target

When you first run the WWW it will create you a SQLLite database as part of unnattended install with the credentials:

- Email: "admin@example.com"
- Password: "1234567890"

This database should be committed to your repository, so when we review the assessment, we can see what has been completed and review the way you have configured the CMS.

## Acceptance Criteria

1. The Projects should build and be able to be ran without issue
2. Product data should be retrieved from the API and consumed by the CMS
3. The data should be output in a way that is logical as a "list of products" that you may look at if you were viewing a product catalogue on an eCommerce site
4. A non-technical CMS user should be able to move the output around and configure it on any page or section of a page on the site
5. The output should have at least basic styling so that it is not just a HTML list of products or JSON blob
6. Products that are in an invalid state should visually be marked as such in the rendered output