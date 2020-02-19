Feature: TestExtenstions
	Test the testing extentions


Background: 
Given I reset the TimeProvider
And I wait 2 second

Scenario: StartOfWeek
Given I Test Extention Method StartOfWeek with the following values
| TargetDate  | DayOfWeek | Expected    |
| 25 Nov 2019 | Monday    | 25 Nov 2019 |
| 25 Nov 2019 | Tuesday   | 26 Nov 2019 |
| 25 Nov 2019 | Wednesday | 27 Nov 2019 |
| 25 Nov 2019 | Thursday  | 28 Nov 2019 |
| 25 Nov 2019 | Friday    | 29 Nov 2019 |
| 25 Nov 2019 | Saturday  | 30 Nov 2019 |
| 25 Nov 2019 | Sunday    | 01 Dec 2019 |
| 07 Mar 2016 | Monday    | 07 Mar 2016 |
| 07 Mar 2016 | Tuesday   | 08 Mar 2016 |
| 07 Mar 2016 | Wednesday | 09 Mar 2016 |
| 07 Mar 2016 | Thursday  | 10 Mar 2016 |
| 07 Mar 2016 | Friday    | 11 Mar 2016 |
| 07 Mar 2016 | Saturday  | 12 Mar 2016 |
| 07 Mar 2016 | Sunday    | 13 Mar 2016 |
| 01 Mar 2012 | Monday    | 27 Feb 2012 |
| 01 Mar 2012 | Tuesday   | 28 Feb 2012 |
| 01 Mar 2012 | Wednesday | 29 Feb 2012 |
| 01 Mar 2012 | Thursday  | 01 Mar 2012 |
| 01 Mar 2012 | Friday    | 02 Mar 2012 |
| 01 Mar 2012 | Saturday  | 03 Mar 2012 |
| 01 Mar 2012 | Sunday    | 04 Mar 2012 |


Scenario: GetDayInWeek1
Given I set the TimeProvider date to '6 Nov 2019 13:34:56'
And I wait 2 second
Then I check extension method GetDayInWeek returns the following
| Value     | Expected    |
| Monday    | 4 Nov 2019  |
| Tuesday   | 5 Nov 2019  |
| Wednesday | 6 Nov 2019  |
| Thursday  | 7 Nov 2019  |
| Friday    | 8 Nov 2019  |
| Saturday  | 9 Nov 2019  |
| Sunday    | 10 Nov 2019 |


Scenario: GetDayInWeek2
Given I set the TimeProvider date to '1 Mar 2012 13:34:56'
And I wait 2 second
Then I check extension method GetDayInWeek returns the following
| Value     | Expected    |
| Monday    | 27 Feb 2012 |
| Tuesday   | 28 Feb 2012 |
| Wednesday | 29 Feb 2012 |
| Thursday  | 1 Mar 2012  |
| Friday    | 2 Mar 2012  |
| Saturday  | 3 Mar 2012  |
| Sunday    | 4 Mar 2012  |


Scenario: GetFirstDayOfWeek
Given I set the TimeProvider date to '29 Feb 2012 13:34:56'
And I wait 2 second
Given I check the date time extenstion GetFirstDayOfWeek
| Value       | Expected    |
| 1 Mar 2012  | 27 Feb 2012 |
| 2 Mar 2012  | 27 Feb 2012 |
| 3 Mar 2012  | 27 Feb 2012 |
| 4 Mar 2012  | 27 Feb 2012 |
| 27 Feb 2012 | 27 Feb 2012 |
| 28 Feb 2012 | 27 Feb 2012 |
| 29 Feb 2012 | 27 Feb 2012 |

Scenario:ToGpsSector
Given I check ToGpsSector
| Value              | Expected |
| 5.00°21.04'0.00" N | N        |
| 5.00°21.04'0.00" E | E        |
| 5.00°21.04'0.00" S | S        |
| 5.00°21.04'0.00" W | W        |
| 5.00°21.04'0.00" X |          |
|                    |          |


Scenario:ToGpsDegrees
Given I check ToGpsDegrees
| Value              | Expected |
| 5.11°21.12'1.45" N | 5.11     |
| 5.22°21.22'2.56" E | 5.22     |
| 5.33°21.23'3.78" S | 5.33     |
| 5.44°21.34'4.12" W | 5.44     |
| 5.55°21.56'5.34" X | 5.55     |



Scenario:ToGpsMinutes
Given I check ToGpsMinutes
| Value               | Expected |
| 5.11°21.11'1.45" N  | 21.11    |
| 5.22°21.22'2.56" E  | 21.22    |
| 5.33°21.33'3.78" S  | 21.33    |
| 5.44°21.44'4.12" W  | 21.44    |
| 5.55°21.55'5.34" X  | 21.55    |
| 5.55°21.666'5.34" X | 21.666   |



Scenario:ToGpsSeconds
Given I check ToGpsSeconds
| Value              | Expected |
| 5.11°21.12'1.45" N | 1.45     |
| 5.22°21.22'2.56" E | 2.56     |
| 5.33°21.23'3.78" S | 3.78     |
| 5.44°21.34'4.12" W | 4.12     |
| 5.55°21.56'5.34" X | 5.34     |
