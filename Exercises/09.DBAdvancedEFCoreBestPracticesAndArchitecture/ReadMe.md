# 1.Exercises: Best Practices and Architecture

This document defines the **exercise assignments** for the [&quot;Databases Advanced – EF Core&quot; course @ Software University](https://softuni.bg/trainings/1741/databases-advanced-entity-framework-october-2017).

# 2.Best Practices and Architecture

1. 1.Photo Share System

You are given a project [skeleton](http://svn.softuni.org/admin/svn/DB-Fundamentals/DB-Advanced-EntityFramework/Feb-2017/08.%20DB-Advanced-EntityFramework-Best%20Practices-and-Architecture/08.%20DB-Advanced-EntityFramework-Best-Practices-and-Architecture-PhotoShare-Skeleton.zip) of a **Photo Sharing System**. Take a look at it to get more familiar with that project.  The database is modeled by code first approach and the models are fine (in other words there is nothing to modify in **PhotoShare.Models** project).

But the other projectс **Phot**** o ****Share.Clien**** t **and** Phot ****o**** Share.Service **are poorly written. Your task is to** improve the architecture of the project.** Seed some data in the database.

Then **implement the missing commands** by the hints given in each command class and **fix any bugs** in the already implemented code.

### System functionality

The photo share system contains the following commands:

- **Register**** User &lt;username&gt; &lt;password&gt; &lt;repeat-password&gt; &lt;email&gt;**
Registers a new user.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | User [username] was registered successfully! | None |
| Passwords do not match | Passwords do not match! | ArgumentException |
| Username is taken | Username [username] is already taken! | InvalidOperationException |

Any other validation is already implemented and it should stay as is.

- **AddTown &lt;town Name&gt; &lt;country Name&gt;**

Adds new  town. Town names must be unique.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Town [town] was added successfully! | None |
| Town already exists | Town [town] was already added! | ArgumentException |

Any other validation is already implemented and it should stay as is.

- **ModifyUser &lt;username&gt; &lt;property&gt; &lt;new value&gt;**
Modifies current user.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | User [user] [property] is [value]. | None |
| User does not exist | User [username] not found! | ArgumentException |
| Property not found | Property [property] not supported! | ArgumentException |
| Value not valid for that property | Value [value] not valid.[DetailedMessage] | ArgumentException |

**       ** The above command may be executed in the following formats:

ModifyUser &lt;username&gt; Password &lt;NewPassword&gt;

- --Password must contain at least one lowercase letter and digit. If not:
  - Detailed Message - &quot; **Invalid Password**&quot;

ModifyUser &lt;username&gt; BornTown &lt;newBornTownName&gt;

- --Town must exist in database. If not:
  - Detailed Message – &quot;**Town [town] not found!**&quot;

      ModifyUser &lt;username&gt; CurrentTown &lt;newCurrentTownName&gt;

- --Town must exist in database. If not:
  - Detailed Message – &quot;**Town [town] not found!**&quot;

 Any other format different than from all the above formats is invalid.

- **DeleteUser &lt;username&gt;**
Deletes a user.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | User [username] was deleted successfully! | None |
| User does not exist | User [username] not found! | ArgumentException |
| User is already deleted | User [username] is already deleted! | InvalidOperationException |

- **AddTag &lt;tag&gt;**
Adds a tag. Tag names should be unique.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Tag [tag] was added successfully! | None |
| Tag already exists | Tag [tag] exists! | ArgumentException |

Tag validation is already implemented and should stay as is.

- **CreateAlbum &lt;username&gt; &lt;albumTitle&gt; &lt;BgColor&gt; &lt;tag1&gt; &lt;tag2&gt;...&lt;tagN&gt;**
Adds an album. Album names should be unique.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Album [Album] successfully created! | None |
| User does not exist | User [username] not found! | ArgumentException |
| Album does exist | Album [album] exists! | ArgumentException |
| Background color does not exist | Color [color] not found! | ArgumentException |
| If any tag is not found in database | Invalid tags! | ArgumentException |

- **AddTagTo &lt;album&gt; &lt;tag&gt;**
Adds a tag.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Tag [tag] added to [album]! | None |
| Album or tag does not exist | Either tag or album do not exist! | ArgumentException |

- **AddFriend &lt;username1&gt; &lt;username2&gt;**
The first user adds the second one as a [friend](http://orig13.deviantart.net/006e/f/2013/297/c/6/lol_amumu_by_enzanblues456-d6rnrta.jpg). :)

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Friend [username2] added to [username1] | None |
| Any of the users do not exist. | [user\*] not found!
_\*Pick the first not existing possible user_ | ArgumentException |
| They are already friends | [username2] is already a friend to [username1] | InvalidOperationException |

- **AcceptFriend &lt;username1&gt; &lt;username2&gt;**


| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | [username1] accepted [username2] as a friend | None |
| Any of the users do not exist. | [user\*] not found!
_\*Pick the first not existing possible user_ | ArgumentException |
| They are already friends | [username2] is already a friend to [username1] | InvalidOperationException |
| There is no such friend request | [username2] has not added [username1] as a friend | InvalidOperationException |

- **ListFriends &lt;username&gt;**
List usernames of all friends for given user sorted alphabetically.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Friends:-[username1]…-[usernameN] | None |
| User does not have any friends. | No friends for this user. :( | None |
| User does not exist | User [user] not found! | ArgumentException |

- **ShareAlbum &lt;albumId&gt; &lt;username&gt; &lt;permission&gt;**
Makes specified user to be part of given album.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Username [user] added to album [album] ([permission]) | None |
| Album does not exist | Album [albumId] not found! | ArgumentException |
| User does not exist | User [user] not found! | ArgumentException |
| Permission not valid | Permission must be either &quot;Owner&quot; or &quot;Viewer&quot;! | ArgumentException |

- **UploadPicture &lt;albumName&gt; &lt;pictureTitle&gt; &lt;pictureFilePath&gt;**
Creates picture and atteches it to specified album

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Picture [picture] added to [album]! | None |
| Album does not exist | Album [Album] not found! | ArgumentException |

- **Exit**
Exits application.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | Good Bye! | None |

If command is **NOT** in format specified above (either command name is wrong or input arguments count) throw **InvalidOperationExceptio**** n **with message: &quot;** Command &lt;CommandName&gt; not valid!**&quot;.

### Examples

| **Input** | **Output** |
| --- | --- |
| RegisterUser admin abc123 abc123 user@softuni.bgModifyUser admin BornTown SofiaAddTown Sofia BulgariaModifyUser admin BornTown SofiaUploadPicture Nature Vitosha C://Pictures/Vitosha.pngCreateAlbum admin Nature Magenta natureAddTag natureCreateAlbum admin Nature Magenta natureUploadPicture Nature Vitosha C://Pictures/Vitosha.pngExit  | User admin was registered successfully!Value Sofia not valid!
**Town**  **Sofia**  **not found!** Town **Sofia** was added successfully!User admin BornTown is Sofia.Album Nature not found!Invalid tags!Tag #nature was added successfully!Album Nature successfully created!Picture Vitosha added to Nature!Good Bye! |
| RegisterUser peter pan123 pan123 peter@pan.comRegisterUser peter aaa a123 pesho@pan.comRegisterUser capt hook123 hook123 capitan@hook.comAddFriend peterr cappAddFriend peter cappAddFriend peter captRegisterUser jack jack123 jack123 jack@j.comAddFriend peter jackAcceptFriend jack peterAcceptFriend capt peterPrintFriendsList peter RegisterUser userExit | User peter was registered successfully!Username peter is already taken!User capt was registered successfully!User peterr not found!User capp not found!Friend peter added to capt!User jack was registered successfully!Friend peter added to jack!Friend jack accepted peter as friendFriend capt accepted peter as friendFriends-capt-jackCommand RegisterUser not valid!Good Bye! |
| RegisterUser tomCat tom123 tom123 tom@t.comRegisterUser jerry jerry123 jerry123 jerry@j.comRegisterUser butch butch123 butch123 butch@b.comAddTag #cartoonCreateAlbum tomCat Tom&amp;Jerry Blue cartoonShareAlbum 1 jerry OwnerAddTag #childhoodAddTagTo Tom&amp;Jerry childhoodExit | User tom was registered successfully!User jerry was registered successfully!User jerry was registered successfully!Tag #cartoon was added successfully!Album Tom&amp;Jerry successfully created!Username jerry added to album Tom&amp;Jerry (Owner)Tag #childhood was added successfully!Tag #childhood added to Tom&amp;Jerry!Good Bye! |

1. 2.Extend Photo Share System

Extend the **Photo Share System** by implementing two more commands:

- **Login &lt;username&gt; &lt;password&gt;**
Logs a user into the system and keep a reference to it until the &quot;Logout&quot; command is called.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | User [username] successfully logged in! | None |
| Either user does not exist or password does not match | Invalid username or password! | ArgumentException |
| User has logged in already | You should logout first! | ArgumentException |

- **Logout**
Logs out a user from the system.

| **Case** | **Message** | **Exception** |
| --- | --- | --- |
| Success | User [username] successfully logged out! | None |
| There is no user logged in. | You should log in first in order to logout. | InvalidOperationException |

**Modify all commands accordingly**.

Logged user can:

- Modify his own profile
- Add friends to himself
- Add tag
- Add town
- Create an album (only if he is owner of the album)
- Share an album (only if he is owner of the album)
- Upload picture (only if he is owner of the album that picture is uploaded to)
- Add tag to album (only if he is owner of the album)
- Delete user (can delete only himself/herself)
- List friends of any user
- Logout

Non-logged user can:

- List friends of any user
- Register
- Login

If any of these rules are violated print: &quot; **Invalid credentials!**&quot;and throw **InvalidOperationException**.

### Examples

| **Input** | **Output** |
| --- | --- |
| RegisterUser thor tor123 tor123 tor@t.comLogin thor tor1234Login thor tor123Login thor tor123AddTag thunderRegisterUser loki loki123 loki123 loki@l.comLogoutRegisterUser loki loki123 loki123 loki@l.comLogin loki loki123Exit   | User thor was registered successfully!Invalid username or password!
User thor successfully logged in!Invalid Credentials!Tag #thunder was added successfully!Invalid Credentials!User tor successfully logged out!User loki was registered successfully!
User loki successfully logged in!Good Bye! |
| AddTown Asgard AsgardRegisterUser loki loki123 loki123 loki@l.comRegisterUser thor tor123 tor123 tor@t.comLogin thor tor123AddTown Asgard AsgardModifyUser thor CurrentTown AsgardModifyUser loki CurrentTown AsgardMakeFriends thor lokiMakeFriends loki thorCreateAlbum thor TalesOfAsgard BlackCreateAlbum loki FalseGod BlackShareAlbum 1 loki ViewerUploadPicture TalesOfAsgard Thor D:\\images\thor.pngAddTag thunderAddTagTo TalesOfAsgard thunderListFriends thorListFriends lokiDeleteUser thorDeleteUser lokiLogoutRegisterUser odin odin123 odin123 odin@d.comLogin loki loki123ShareAlbum 1 odin OwnerUploadPicture TalesOfAsgard Loki D:\\images\loki.pngAddTag #destructionAddTagTo TalesOfAsgard #destructionExit | Invalid credentials!User loki was registered successfully!User thor was registered successfully!User thor successfully logged in!Town Asgard was added successfully!User thor CurrentTown is Asgard.Invalid credentials!Friend loki added to thor!Invalid credentials!Album TalesOfAsgard successfully created!Invalid credentials!User loki added to album TalesOfAsgard(Viewer)Picture Thor added to TalesOfAsgard!Tag #thunder was added successfully!Tag #thunder added to TalesOfAsgard!Friends:-lokiNo friends for this user. :(User thor was deleted successfully!Invalid credentials!User thor successfully logged out!User odin was registered successfully!User loki successfully logged in!Invalid credentials!Invalid credentials!Tag #destruction was added successfully!Invalid credentials!Good Bye! |

1. 3.\*Bus Tickets System

Your task is to design a database for **Bus Tickets System** using the **code first** approach. The database should keep information about:

- **bus companies** - name, nationality, rating
- **tickets** - price, seat, customer, trip
- **customers** - first name, last name, date of birth, gender, home town
- **trips** - departure time, arrival time, status, origin bus station, destination bus station, bus company
- **bus stations** - name, town
- **towns** - name, country
- **reviews** - content, grade, bus station, customer, date and time of publishing
- **bank accounts** - account number, balance, customer

Each ticket is bought from a customer for a certain trip. A customer has only one home town. Every trip has an origin and a destination, a bus station and it is organized by only one bus company. A bus station is located in only one town and one town can have many bus stations in it. Reviews are written for a certain bus company and a bus company can have many reviews. One customer can write many reviews but a single review can be written only by one customer. Bank account can be owned by one customer and each customer can own only one bank account.

Gender can be only male, female or not specified. The status of the trip can be departed, arrived, delayed or cancelled. Grade of a review can any be a floating-point number in range [1, 10].

When database is up and running **seed** it with some **sample records in each table**.

Now let&#39;s **make a command line application** that would **use that database and provide the following functionalities** :

- **print information for trips for a given bus station –  ** Print a list of arrivals and departures buses for given bus station id in the format provided below
- **buy ticket –** Insert new ticket and reduce the balance from customers&#39; bank account. Consider managing all cases such as the customer does not have enough money in his/her bank account.
- **publish review –** insert new review from given user into the database
- **print reviews –** print a list of reviews for a given bus company in the format provided below

| **Command** | **Successful Output** |
| --- | --- |
| print-info {Bus Station ID} | {Bus Station Name}, {Town}Arrivals:From {origin station} | Arrive at: {Arrival Time} | Status: {status}Departures:To {destination station} | Depart at: {Departure Time} | Status {status} |
| buy-ticket {customer ID} {Trip ID} {Price} {Seat} | Customer {Full Name} bought ticket for trip {Trip ID} for {Price} on seat {Seat} |
| publish-review {Customer ID} {Grade} {Bus Company Name} {Content} | Customer {Full Name} published review for company {Company Name} |
| print-reviews {Bus Company ID} | {Id} {Grade} {Date and Time}{Customer Full Name}{Content} |

The application should **receive and execute unlimited number of commands** until the **&quot;exit&quot;** command is received.

Use all of the **best practices** you know to design and write your application.

### Examples

| **Input** | **Output** |
| --- | --- |
| print-info 1exit  | Sofia Central Station, SofiaArrivals:From: Burgas | Arrive at: 14:30 | Status: DepartedFrom: Svishtov | Arrive at: 07:30 | Status: ArrivedFrom: V.Tarnovo | Arrive at: 14:30 | Status: DepartedDepartures:To: Varna | Depart at: 14:40 | Status: DelayedTo: Plovdiv | Depart at: 15:30 | Status: Cancelled |
| buy-ticket 2 323 14.20 A4buy-ticket 3 333 -12.00 B8buy-ticket 9 874 6.90 A1exit | Customer John Doe bought ticket for trip 323 for $14.20 on seat A4Invalid priceInsufficient amount of money for customer Harry Potter with bank account number BGR33133235 |
| publish-review 2 10 BusTrip2000 Excellent trip! Look forward to travel again.publish-review 3 2 BusCompany2001 Awful and dirty bus. Cannot recommend it to anyone.exit | John Doe&#39;s review was succesfully publishedChuck Norris&#39; review was successfully published |
| publish-review 2 8.5 BusTrip2000 Would recommend it but the driver needs to stop smoking while driving.print-reviews 1exit | John Doe&#39;s review was succesfully published1 10 2016/11/15 10:46:18John DoeExcellent trip! Look forward to travel again.2 8.5 2016/11/18 12:20:00John DoeWould recommend it but the driver needs to stop smoking while driving. |

1. 4.\*\*Extend Bus Tickets System

Implement one additional command **change-trip-status**. That command would change the status of a given trip

| **Command** | **Successful Output** |
| --- | --- |
| change-trip-status {Trip Id} {New Status} | Trip from {Origin Bus Station Town} to {Destination Bus Station Town} on {Trip Departure Date and Time}Status changed from {Old Status} to {New Status} |

Add a **new table to the database** to keep information about **arrived trips** (actual arrival time, origin bus station, destination bus station, passengers count).

In case a **trip status is changed to Arrived, automatically add new record** in the **arrived trips table** with the required information.

### Examples

| **Input** | **Output** |
| --- | --- |
| change-trip-status 2 Departedchange-trip-status 3 Cancelledchange-trip-status 134 Arrivedexit  | Trip from Burgas to Sofia on 2016/11/15 10:45:00Status changed from Cancelled to DepartedTrip from Sofia to Varna on 2016/11/15 10:00:00Status changed from Delayed to CancelledTrip from Plovdiv to Varna on 2016/11/14 15:30:00Status changed from Departed to ArrivedOn 2016/11/14 22:32:43 - 34 passengers arrived at Varna from Plovdiv |