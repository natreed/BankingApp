# Bank Account App in Asp.Net Core

This excercise was developed in response to a request for a code sample for Company 'X'. 
The homework was to create a banking application with a backend implemented in C#.
The task did not require implementing a front end (a CLI would have been sufficient). 
But since I had not worked with asp before, I thought I'd try using asp.net core mvc for the and the entity framework for my database context.  

This app only demonstrates basic operations of opening an account, logging in, checking balance, making a deposit or withdrawal, checking transaction
history and logging out. Additionally

Since this was not a database excercise I kept the Schema as simple as possible. All data is accessed and updated through the Customer entity. I 
also did not make speed or efficiency a concern. My method was store and retrieve data by any means. Requests are first come first serve. There is
no need for a strategy to handle simultaneous requests in this case because of the one to one relationship between a customer and an account.
(i.e. only one customer should be able to make changes). In a more realistic scenario, there would be automatic deposits and withdrawals coming
from credit card companies, utilities, employers, etc. And that would be a full-on database project.

If you would like to know more about this project, comment, or make suggestions I'm open to discussion. Click contact info if you are interested.
If you come to the conclusion that I should look for another line of work, I'd like to hear that too:)

Thank you for taking a look!

### Prerequisites

Visual Studio 2017.
This project runs on ASP.NET Core 2.1, EntityFrameworkCore2.1.4

## Getting Started
### This program has only been tested on a Windows 10 system using Internet Explorer!
```
- Clone the repository.
- Open Visual Studio 2017
- Build by locating the Directory and running BankingApp.csproj
- Run the project. (To look at seeded table entries, go to /Data/DBContextInitializer)
- Click on the 'Customers' link in the navbar to see the seeded customer data.
- Click home in the navbar and then click the Create Customer link to create a new customer.
- At the Login prompt enter your new customer (first name, last name, and password).
- This should open the account management page for that customer. (The current balance should be 0.00)
- Make updates or withdrawals using the provided fields.
- The account balance should update in real time and a transaction line should appear in the transaction
list at the bottom of the page.
```

## Notes on running the program

Don't forget your password! There is no implementation for password recovery. That's what password 
managers are for!

There is no overdraft protection at this bank.

If you do something 'illegal', such as try to withdraw more 
than your account balance, you may find that nothing happens. This behavior is intentional. 

If you click on 'Customers' you will notice that at the end of each customer entry, there is an 
option to delete the customer. This will remove the customer and account completely from the database.
Just pretend, if you do this, that you are the banker and you are closing the account on the behalf of a 
customer.

### Testing

```
- Made sure links work!
- Made sure that when customer logs out, they need to log back in to access account.
- Tested starting with brand new database, adding a customer and logging in updating account/customer information.
- Tested for bad input or illegal operations in the ManageAccount window.
- A better testing strategy might be the hypothetical next step.
- All testing to this point has been manual (OUCH).
```

## Known Bugs
```
- Security: If you logout of your account and the last url is a post-handler (i.e onPostDeposit()), the page displays a 'this page was just here a second ago message'. Explorer allows 
a 'retry' that seems to by-pass reloading the page and in doing so misses the user verification step in the onGet method.
		- An easy fix might be to exit the program entirely on logout.
```
## Author

* **Nathan Reed** - *Initial work* - (https://github.com/natreed/BankingApp)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Inspiration taken from the Microsoft ASP.NET Core Razor tutorial. 
* https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-2.2&tabs=visual-studio

