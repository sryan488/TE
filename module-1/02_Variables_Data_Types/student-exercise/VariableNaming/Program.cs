using System;

namespace VariableNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. 4 birds are sitting on a branch. 1 flies away. How many birds are left on
            the branch?
            */

            // ### EXAMPLE:
            int initialNumberOfBirds = 4;
            int birdsThatFlewAway = 1;
            int remainingNumberOfBirds = initialNumberOfBirds - birdsThatFlewAway;

            /*
            2. There are 6 birds and 3 nests. How many more birds are there than
            nests?
            */

            // ### EXAMPLE:
            int numberOfBirds = 6;
            int numberOfNests = 3;
            int numberOfExtraBirds = numberOfBirds - numberOfNests;



            /*
            3. 3 raccoons are playing in the woods. 2 go home to eat dinner. How
            many raccoons are left in the woods?
            */

            int numberOfRacoons = 3;
            int numberOfRacoonsThatWentHome = 2;
            int numberOfRacoonsLeft = numberOfRacoons - numberOfRacoonsThatWentHome;
            Console.WriteLine(numberOfRacoonsLeft);

            /*
            4. There are 5 flowers and 3 bees. How many less bees than flowers?
            */

            int numberOfFlowers = 5;
            int numberOfBees = 3;
            int numberOfBeesLessThanFlowers = numberOfFlowers - numberOfBees;
            Console.WriteLine(numberOfBeesLessThanFlowers);

            /*
            5. 1 lonely pigeon was eating breadcrumbs. Another pigeon came to eat
            breadcrumbs, too. How many pigeons are eating breadcrumbs now?
            */

            int lonelyPigeon = 1;
            int anotherPigeon = 1;
            int eatingPigeons = lonelyPigeon + anotherPigeon;
            Console.WriteLine(eatingPigeons);

            /*
            6. 3 owls were sitting on the fence. 2 more owls joined them. How many
            owls are on the fence now?
            */

            int owlsOnFence = 3;
            int joiningOwls = 2;
            int owlFenceParty = owlsOnFence + joiningOwls;
            Console.WriteLine(owlFenceParty);

            /*
            7. 2 beavers were working on their home. 1 went for a swim. How many
            beavers are still working on their home?
            */

            int workingBeavers = 2;
            int swimmingBeavers = 1;
            int beaversStillWorking = workingBeavers - swimmingBeavers;
            Console.WriteLine(beaversStillWorking);

            /*
            8. 2 toucans are sitting on a tree limb. 1 more toucan joins them. How
            many toucans in all?
            */

            int toucansSitting = 2;
            int joiningToucans = 1;
            int totalToucans = toucansSitting + joiningToucans;
            Console.WriteLine(totalToucans);

            /*
            9. There are 4 squirrels in a tree with 2 nuts. How many more squirrels
            are there than nuts?
            */

            int squirrelsInTree = 4;
            int nutsInTree = 2;
            int nutlessSquirrels = squirrelsInTree - nutsInTree;
            Console.WriteLine(nutlessSquirrels);

            /*
            10. Mrs. Hilt found a quarter, 1 dime, and 2 nickels. How much money did
            she find?
            */

            int numQuarters = 1;
            int numDimes = 1;
            int numNickels = 2;
            float totalOfCoins = (numQuarters *.25f) + (numDimes * .10f) + (numNickels * .05f);
            Console.WriteLine(totalOfCoins);

            /*
            11. Mrs. Hilt's favorite first grade classes are baking muffins. Mrs. Brier's
            class bakes 18 muffins, Mrs. MacAdams's class bakes 20 muffins, and
            Mrs. Flannery's class bakes 17 muffins. How many muffins does first
            grade bake in all?
            */

            int numBrierMuffins = 18;
            int numMacMuffins = 20;
            int numFlanMuffins = 17;
            int totalNumberOfMuffins = (numBrierMuffins + numMacMuffins + numFlanMuffins);
            Console.WriteLine(totalNumberOfMuffins);

            /*
            12. Mrs. Hilt bought a yoyo for 24 cents and a whistle for 14 cents. How
            much did she spend in all for the two toys?
            */

            decimal priceOfYoyo = .24M;
            decimal priceOfWhistle = .14M;
            decimal totalPriceOfToys = priceOfYoyo + priceOfWhistle;
            Console.WriteLine(totalPriceOfToys);

            /*
            13. Mrs. Hilt made 5 Rice Krispie Treats. She used 8 large marshmallows
            and 10 mini marshmallows.How many marshmallows did she use
            altogether?
            */

            int numLargeMallows = 8;
            int numMiniMallows = 10;
            int totalMallows = numLargeMallows + numMiniMallows;
            Console.WriteLine(totalMallows);

            /*
            14. At Mrs. Hilt's house, there was 29 inches of snow, and Brecknock
            Elementary School received 17 inches of snow. How much more snow
            did Mrs. Hilt's house have?
            */

            int inchesOfHouseSnow = 29;
            int inchesOfSchoolSnow = 17;
            int differenceOfSnow = inchesOfHouseSnow - inchesOfSchoolSnow;
            Console.WriteLine(differenceOfSnow);


            /*
            15. Mrs. Hilt has $10. She spends $3 on a toy truck and $2 on a pencil
            case. How much money does she have left?
            */

            int hiltDollars = 10;
            int priceOfTruck = 3;
            int pricedOfPencil = 2;
            int dollarsLeft = hiltDollars - priceOfTruck - pricedOfPencil;
            Console.WriteLine(dollarsLeft);

            /*
            16. Josh had 16 marbles in his collection. He lost 7 marbles. How many
            marbles does he have now?
            */

            int totalMarbles = 16;
            int lostMarbles = 7;
            int marblesLeft = totalMarbles - lostMarbles;
            Console.WriteLine(marblesLeft);

            /*
            17. Megan has 19 seashells. How many more seashells does she need to
            find to have 25 seashells in her collection?
            */

            int numSeashells = 19;
            int numSeashellsDesired = 25;
            int numSeashellsToFind = numSeashellsDesired - numSeashells;
            Console.WriteLine(numSeashellsToFind);

            /*
            18. Brad has 17 balloons. 8 balloons are red and the rest are green. How
            many green balloons does Brad have?
            */

            int totalBalloons = 17;
            int redBalloons = 8;
            int greenBalloons = totalBalloons - redBalloons;
            Console.WriteLine(greenBalloons);

            /*
            19. There are 38 books on the shelf. Marta put 10 more books on the shelf.
            How many books are on the shelf now?
            */

            int booksOnShelf = 38;
            int booksAdded = 10;
            int totalBooksOnShelf = booksOnShelf + booksAdded;
            Console.WriteLine(totalBooksOnShelf);

            /*
            20. A bee has 6 legs. How many legs do 8 bees have?
            */

            int legsOnBee = 6;
            int numOfBees = 8;
            int totalNumberOfLegs = legsOnBee * numOfBees;
            Console.WriteLine(totalNumberOfLegs);

            /*
            21. Mrs. Hilt bought an ice cream cone for 99 cents. How much would 2 ice
            cream cones cost?
            */

            decimal priceOfIceCream = .99M;
            int numberOfIceCreamCones = 2;
            decimal priceOfTwoCones = priceOfIceCream * numberOfIceCreamCones;
            Console.WriteLine(priceOfTwoCones);

            /*
            22. Mrs. Hilt wants to make a border around her garden. She needs 125
            rocks to complete the border. She has 64 rocks. How many more rocks
            does she need to complete the border?
            */

            int numRocks = 64;
            int numRocksTotal = 125;
            int numRocksNeeded = numRocksTotal - numRocks;
            Console.WriteLine(numRocksNeeded);

            /*
            23. Mrs. Hilt had 38 marbles. She lost 15 of them. How many marbles does
            she have left?
            */

            int numMarbles = 38;
            int missingMarbles = 15;
            int newAmountOfMArbles = numMarbles - missingMarbles;
            Console.WriteLine(newAmountOfMArbles);

            /*
            24. Mrs. Hilt and her sister drove to a concert 78 miles away. They drove 32
            miles and then stopped for gas. How many miles did they have left to drive?
            */

            int numMiles = 78;
            int numMilesToGas = 32;
            int numMilesLeft = numMiles - numMilesToGas;
            Console.WriteLine(numMilesLeft);

            /*
            25. Mrs. Hilt spent 1 hour and 30 minutes shoveling snow on Saturday
            morning and 45 minutes shoveling snow on Saturday afternoon. How
            much total time did she spend shoveling snow?
            */

            int timeShovelingAm = 90;
            int timeShovelingPm = 45;
            decimal totalTimeShoveling = timeShovelingAm + timeShovelingPm;
            Console.WriteLine(totalTimeShoveling);

            /*
            26. Mrs. Hilt bought 6 hot dogs. Each hot dog cost 50 cents. How much
            money did she pay for all of the hot dogs?
            */

            int totalDogs = 6;
            decimal priceOfDogs = .50M;
            decimal totalPriceOfDogs = totalDogs * priceOfDogs;
            Console.WriteLine(totalPriceOfDogs);


            /*
            27. Mrs. Hilt has 50 cents. A pencil costs 7 cents. How many pencils can
            she buy with the money she has?
            */

            int totalCents = 50;
            int pencilPrice = 7;
            int numOfPencilsPossible = (totalCents / pencilPrice);
            Console.WriteLine(numOfPencilsPossible);

            /*
            28. Mrs. Hilt saw 33 butterflies. Some of the butterflies were red and others
            were orange. If 20 of the butterflies were orange, how many of them
            were red?
            */

            int butterfliesSaw = 33;
            int orangeButterflies = 20;
            int redButterflies = butterfliesSaw - orangeButterflies;
            Console.WriteLine(redButterflies);

            /*
            29. Kate gave the clerk $1.00. Her candy cost 54 cents. How much change
            should Kate get back?
            */

            decimal dollarsPaid = 1.00m;
            decimal costOfCandy = .54m;
            decimal katesChange = dollarsPaid - costOfCandy;
            Console.WriteLine(katesChange);

            /*
            30. Mark has 13 trees in his backyard. If he plants 12 more, how many trees
            will he have?
            */

            int numTrees = 13;
            int numNewTrees = 12;
            int totalNumberOfTrees = numTrees + numNewTrees;
            Console.WriteLine(totalNumberOfTrees);

            /*
            31. Joy will see her grandma in two days. How many hours until she sees
            her?
            */

            int numOfDays = 2;
            int numOfHoursInDay = 24;
            int numOfHoursUntilGrandmaTime = numOfDays * numOfHoursInDay;
            Console.WriteLine(numOfHoursUntilGrandmaTime);

            /*
            32. Kim has 4 cousins. She wants to give each one 5 pieces of gum. How
            much gum will she need?
            */

            int kimsCousins = 4;
            int piecesOfGumPerCousin = 5;
            int totalPiecesNeeded = kimsCousins * piecesOfGumPerCousin;
            Console.WriteLine(totalPiecesNeeded);

            /*
            33. Dan has $3.00. He bought a candy bar for $1.00. How much money is
            left?
            */

            decimal danDollars = 3.00m;
            decimal priceOfCandy = 1.00m;
            decimal moneyLeft = danDollars - priceOfCandy;
            Console.WriteLine(moneyLeft);


            /*
            34. 5 boats are in the lake. Each boat has 3 people. How many people are
            on boats in the lake?
            */

            int totalBoats = 5;
            int peopleInEachBoat = 3;
            int totalPeopleInLake = totalBoats * peopleInEachBoat;
            Console.WriteLine(totalPeopleInLake);

            /*
            35. Ellen had 380 legos, but she lost 57 of them. How many legos does she
            have now?
            */

            int totalLegos = 380;
            int lostLegos = 57;
            int legosLeft = totalLegos - lostLegos;
            Console.WriteLine(legosLeft);

            /*
            36. Arthur baked 35 muffins. How many more muffins does Arthur have to
            bake to have 83 muffins?
            */

            int bakedMuffins = 35;
            int numberOfMuffinsDesired = 83;
            int numberOfMuffinsLeftToMake = numberOfMuffinsDesired - bakedMuffins;
            Console.WriteLine(numberOfMuffinsLeftToMake);

            /*
            37. Willy has 1400 crayons. Lucy has 290 crayons. How many more
            crayons does Willy have then Lucy?
            */

            int willyHas = 1400;
            int lucyHas = 290;
            int totalWillyHasMore = willyHas - lucyHas;
            Console.WriteLine(totalWillyHasMore);

            /*
            38. There are 10 stickers on a page. If you have 22 pages of stickers, how
            many stickers do you have?
            */

            int stickersOnPage = 10;
            int pagesOfStickers = 22;
            int totalOfStickers = stickersOnPage * pagesOfStickers;
            Console.WriteLine(totalOfStickers);

            /*
            39. There are 96 cupcakes for 8 children to share. How much will each
            person get if they share the cupcakes equally?
            */

            int totalCupcakes = 96;
            int numOfChildren = 8;
            int sharedCupcakes = totalCupcakes / numOfChildren;
            Console.WriteLine(sharedCupcakes);

            /*
            40. She made 47 gingerbread cookies which she will distribute equally in
            tiny glass jars. If each jar is to contain six cookies each, how many
            cookies will not be placed in a jar?
            */

            int totalCookies = 47;
            int cookiesJarsFit = 6;
            int cookiesThatWontFit = totalCookies % cookiesJarsFit;
            Console.WriteLine(cookiesThatWontFit);

            /*
            41. She also prepared 59 croissants which she plans to give to her 8
            neighbors. If each neighbor received and equal number of croissants,
            how many will be left with Marian?
            */

            int totalCroissants = 59;
            int numOfNeighbors = 8;
            int numLeftWithMarian = totalCroissants % numOfNeighbors;
            Console.WriteLine(numLeftWithMarian);

            /*
            42. Marian also baked oatmeal cookies for her classmates. If she can
            place 12 cookies on a tray at a time, how many trays will she need to
            prepare 276 oatmeal cookies at a time?
            */

            int cookiesOnTray = 12;
            int cookiesNeeded = 276;
            int traysNeeded = cookiesNeeded / cookiesOnTray;
            Console.WriteLine(traysNeeded);

            /*
            43. Marian’s friends were coming over that afternoon so she made 480
            bite-sized pretzels. If one serving is equal to 12 pretzels, how many
            servings of bite-sized pretzels was Marian able to prepare?
            */

            int totalPretzals = 480;
            int servingSize = 12;
            int servingsPrepared = totalPretzals / servingSize;
            Console.WriteLine(servingsPrepared);

            /*
            44. Lastly, she baked 53 lemon cupcakes for the children living in the city
            orphanage. If two lemon cupcakes were left at home, how many
            boxes with 3 lemon cupcakes each were given away?
            */

            int totalLemonCupcakes = 53;
            int totalCupcakesLeft = 2;
            int totalCupcakesInBox = 3;
            int totalBoxesGivenAway = (totalLemonCupcakes - totalCupcakesLeft) / totalCupcakesInBox;
            Console.WriteLine(totalBoxesGivenAway);

            /*
            45. Susie's mom prepared 74 carrot sticks for breakfast. If the carrots
            were served equally to 12 people, how many carrot sticks were left
            uneaten?
            */

            int totalCarrots = 74;
            int totalPeople = 12;
            int totalCarrotsLeft = totalCarrots % totalPeople;
            Console.WriteLine(totalCarrotsLeft);

            /*
            46. Susie and her sister gathered all 98 of their teddy bears and placed
            them on the shelves in their bedroom. If every shelf can carry a
            maximum of 7 teddy bears, how many shelves will be filled?
            */

            int totalTeddyBears = 98;
            int totalBearsOnShelf = 7;
            int totalShelvesFilled = totalTeddyBears / totalBearsOnShelf;
            Console.WriteLine(totalShelvesFilled);

            /*
            47. Susie’s mother collected all family pictures and wanted to place all of
            them in an album. If an album can contain 20 pictures, how many
            albums will she need if there are 480 pictures?
            */

            int numMaxPics = 20;
            int numOfPics = 480;
            int numOfAlbumsNeeded = numOfPics / numMaxPics;
            Console.WriteLine(numOfAlbumsNeeded);


            /*
            48. Joe, Susie’s brother, collected all 94 trading cards scattered in his
            room and placed them in boxes. If a full box can hold a maximum of 8
            cards, how many boxes were filled and how many cards are there in
            the unfilled box?
            */

            int totalCards = 94;
            int maxBoxHolds = 8;
            int numberFilledBoxes = totalCards / maxBoxHolds;
            int cardsInUnfilledBox = totalCards % maxBoxHolds;
            Console.WriteLine(numberFilledBoxes);
            Console.WriteLine(cardsInUnfilledBox);


            /*
            49. Susie’s father repaired the bookshelves in the reading room. If he has
            210 books to be distributed equally on the 10 shelves he repaired,
            how many books will each shelf contain?
            */

            int totalBooks = 210;
            int totalShelves = 10;
            int totalBooksOnEachShelf = totalBooks / totalShelves;
            Console.WriteLine(totalBooksOnEachShelf);

            /*
            50. Cristina baked 17 croissants. If she planned to serve this equally to
            her seven guests, how many will each have?
            */

            int totalCroissantsBaked = 17;
            int totalGuest = 7;
            int totalServedToEach = totalCroissantsBaked / totalGuest;
            Console.WriteLine(totalServedToEach);

            /*
                CHALLENGE PROBLEMS
            */

            /*
            Bill and Jill are house painters. Bill can paint a 12 x 14 room in 2.15 hours, while Jill averages
            1.90 hours. How long will it take the two painter working together to paint 5 12 x 14 rooms?
            Hint: Calculate the hourly rate for each painter, combine them, and then divide the total walls in feet by the combined hourly rate of the painters.
            Challenge: How many days will it take the pair to paint 623 rooms assuming they work 8 hours a day?.
            */

            float hoursBillTakes = 2.15f;
            float hoursJillTakes = 1.90f;
            float averageTimeBothTake = (hoursBillTakes + hoursJillTakes) / 2;
            float timeToPaintFiveRooms = averageTimeBothTake * 5;
            Console.WriteLine(timeToPaintFiveRooms);

            float totalHoursToPaintAllRooms = averageTimeBothTake * 623;
            float totalNumberOfDaysItWillTake = totalHoursToPaintAllRooms / 8;
            Console.WriteLine(totalNumberOfDaysItWillTake);


         
         
            /*
            Create and assign variables to hold your first name, last name, and middle initial. Using concatenation,
            build an additional variable to hold your full name in the order of last name, first name, middle initial. The
            last and first names should be separated by a comma followed by a space, and the middle initial must end
            with a period.
            Example: "Hopper, Grace B."
            */



            /*
            The distance between New York and Chicago is 800 miles, and the train has already travelled 537 miles.
            What percentage of the trip has been completed?
            Hint: The percent completed is the miles already travelled divided by the total miles.
            Challenge: Display as an integer value between 0 and 100 using casts.
            */

            Console.ReadLine();
        }
    }
}
