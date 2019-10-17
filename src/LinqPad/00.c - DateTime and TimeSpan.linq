<Query Kind="Statements" />

DateTime whenever;
whenever = DateTime.Today;
whenever.Dump("DateTime.Today");
whenever = DateTime.Now;
whenever.Dump("DateTime.Now");

whenever.Month.Dump("Month value");
whenever.Day.Dump("Day value");
whenever.Year.Dump("Year value");

DateTime tomorrow = DateTime.Today.AddDays(1);
(tomorrow > whenever).Dump("Is tomorrow greater than now?");

var lastDayOfYear = new DateTime(2019, 12, 31);
lastDayOfYear.Dump("The end of this year");

var diff = tomorrow - whenever;
diff.Dump("The difference between tomorrow and now");
diff.GetType().Name.Dump("The data type of diff");