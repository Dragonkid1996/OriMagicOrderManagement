# OriMagic Order Management
---
## Project Overview 
---
### Application Description:
The application will provide an interface for an origami shop owner to sell their products. They will be able to create new models with high levels of detail, including model complexity and number of units, colours needed, etc. They will also be able to remove models which are no longer sold, and modify models to make changes as well. A buyer interface for the application will also be created to allow buyers to peruse the models being sold and add them to a basket. When an order is placed, it will show in the shop owner view.

### Project Goals:

* The project will emulate the development of software using Agile methodologies.
* The application must have:
     * Graphical User Interface frontend 
     * Database backend
     * Business layer to connect the two 
     * The business layer must be fully tested
* The application must be well documented.
* A final project presentation must also be given.

## Class Diagrams
---
![image](https://github.com/Dragonkid1996/OriMagicOrderManagement/blob/main/ProjectImages/OverallClassDiagram.png)

## Entity Relationship Diagram

---

![image](https://github.com/Dragonkid1996/OriMagicOrderManagement/blob/main/ProjectImages/OrigamiERD.jpg)

## WPF

---
[image]

## Sprint Breakdowns
---
![image](https://github.com/Dragonkid1996/OriMagicOrderManagement/blob/main/ProjectImages/ProjectBoard.PNG)



### Sprint 1 - Tuesday 1st December 2020

By the end of this sprint I aimed to have the basis of a three-tier application, setting out the different projects within the solution. I also wanted to build the database, design the CRUD manager, and create a Graphical User Interface.

#### Sprint Goals

* Set out the basics of the application
- [x] Complete User Story 0.1 - Build a Database
- [x] Complete User Story 0.2 - Build a GUI
- [x] Complete User Story 0.4 - Design CRUD Functionality
- [x] Update README
- [x] Commit all changes to Github repository

#### Sprint Review

The database was completed, the GUI was design and the CRUD manager now has the core functionality it needs to build the application on top. I began adding some data to the database as well.

#### Sprint Retrospective

The sprint went rather smoothly, the only blocker was my computer's limitations. However, after waiting a few minutes for it to respond, I was able to get back to work.

![image](https://github.com/Dragonkid1996/OriMagicOrderManagement/blob/main/ProjectImages/ProjectBoardSprint1.PNG)



### Sprint 2 - Wednesday 2nd December 2020

By the end of this sprint I aimed to have basic functionality on the GUI. I aimed to have a list of all models in both the Customer and Owner views, and the ability to create models through the GUI, including the different colours used by that model. I also wanted to have a list of orders to view by the owner.

#### Sprint Goals

* Build GUI functionality
- [x] Complete User Story 1.1 - Create New Models
- [x] Complete User Story 3.3 - View a Model List (Customer) 
- [x] Complete User Story 3.4 - Buy Button
- [x] Complete User Story 2.1 - Order Viewing
- [x] Complete User Story 2.3 - Create Colours
- [x] Update README
- [x] Commit all changes to Github repository

#### Sprint Review

The application now has the ability to create new models, with all different paper colours. It also shows all models in both the customer and owner view, as well as orders placed in the owner view.

#### Sprint Retrospective

The sprint overall was fairly brief. However, there were a couple of blockers I had to deal with. Firstly, my computer struggled to cope with some of the functionality I was putting it through. Secondly, I had rather a hard time completing User Story 1.1, as I just couldn't get it to work. However, after a while, I realised that I needed a constructor within my CRUD Manager class to initialize the properties I was trying to assign to.

![image](https://github.com/Dragonkid1996/OriMagicOrderManagement/blob/main/ProjectImages/ProjectBoardSprint2.PNG)



### Sprint 3 - Thursday 3rd December 2020

By the end of this sprint I intended to have a fully functioning application, so that all that is left to do in the time remaining is to unit test and design the application to look more aesthetically pleasing. This included fully completing the model details window, which also allows updating and removing models. It also included removing orders from the owner's order view once they are completed. Finally, on the customer's side, I had to enable users to add items to the basket and the basket view will then be updated.

#### Sprint Goals

* Finish application functionality

- [x] Complete User Story 3.1 - Save Models to Order
- [x] Complete User Story 3.2 - Customer Basket View
- [x] Complete User Story 2.2 - Model Details Owner View
- [x] Complete User Story 1.2 - Delete Models (Owner)
- [x] Complete User Story 1.3 - Update Models (Owner)
- [x] Complete User Story 2.4 - Complete Orders Removal
- [x] Complete User Story 0.5 - Deal with Exceptions
- [x] Update README
- [x] Add titles to README Sprints
- [x] Add Class Diagram/ERD to README
- [x] Commit all changes to Github repository

#### Sprint Review

The application now works as expected, and does not crash due to unhandled exceptions. It is at a point where it can take new orders from a customer, remove orders once they are completed, create new models, update and remove models if needs be, and view model details so that the owner can view at any time. They can also insert new colours into the database, and use them when creating new models.

#### Sprint Retrospective

The sprint went really smoothly, as I managed to finish everything I needed to on time, including handling exceptions, which I originally hadn't expected to fit into the sprint. The only blocker I had was that I kept adding new user stories to my day, as I was finished with the user stories I had set, and kept finding new features that I hadn't originally thought of when planning the project.

![image](https://github.com/Dragonkid1996/OriMagicOrderManagement/blob/main/ProjectImages/ProjectBoardSprint3.PNG)



