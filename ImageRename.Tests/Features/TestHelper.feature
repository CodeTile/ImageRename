Feature: TestHelper
	Test the TestHelper methods

Scenario: TestHelper.convertToDateTime1
	Given I reset the TimeProvider
	And I TestHelper function convertToDateTime with the following
	| Value                    | Result              | IncludeTime | CurrentDate         |
	| 1 Feb 2000               | 1 Feb 2000          | false       | 6 Nov 2019 13:34:56 |
	| December 1 2222          | 1 Dec 2222          | false       | 6 Nov 2019 13:34:56 |
	| 1 Feb 2000 13:34:43      | 1 Feb 2000 13:34:43 | true        | 6 Nov 2019 13:34:56 |
	| December 1 2222 09:23:48 | 1 Dec 2222 09:23:48 | true        | 6 Nov 2019 13:34:56 |
	| <<now>>                  | 6 Nov 2019 13:34:56 | true        | 6 Nov 2019 13:34:56 |
	| <<today>>                | 6 Nov 2019          | false       | 6 Nov 2019 13:34:56 |
	| <<yesterday>>            | 5 Nov 2019          | false       | 6 Nov 2019 13:34:56 |
	| <<yearstart>>            | 1 Jan 2019          | false       | 6 Nov 2019 13:34:56 |
	| <<monthstart>>           | 1 Nov 2019          | false       | 6 Nov 2019 13:34:56 |
	| <<mondaylastweek>>       | 28 Oct 2019         | false       | 6 Nov 2019 13:34:56 |
	| <<fridaylastweek>>       | 1 Nov 2019          | false       | 6 Nov 2019 13:34:56 |

Scenario: TestHelper.convertToDateTime2
	Given I reset the TimeProvider
	And I TestHelper function convertToDateTime with the following
	| Value                    | Result              | IncludeTime | CurrentDate         |
	| 1 Feb 2000               | 1 Feb 2000          | false       | 4 Feb 2020 23:14:59 |
	| December 1 2222          | 1 Dec 2222          | false       | 4 Feb 2020 23:14:59 |
	| 1 Feb 2000 13:34:43      | 1 Feb 2000 13:34:43 | true        | 4 Feb 2020 23:14:59 |
	| December 1 2222 09:23:48 | 1 Dec 2222 09:23:48 | true        | 4 Feb 2020 23:14:59 |
	| <<now>>                  | 4 Feb 2020 23:14:59 | true        | 4 Feb 2020 23:14:59 |
	| <<today>>                | 4 Feb 2020          | false       | 4 Feb 2020 23:14:59 |
	| <<yesterday>>            | 3 Feb 2020          | false       | 4 Feb 2020 23:14:59 |
	| <<yearstart>>            | 1 Jan 2020          | false       | 4 Feb 2020 23:14:59 |
	| <<monthstart>>           | 1 Feb 2020          | false       | 4 Feb 2020 23:14:59 |
	| <<mondaylastweek>>       | 27 Jan 2020         | false       | 4 Feb 2020 23:14:59 |
	| <<fridaylastweek>>       | 31 Jan 2020         | false       | 4 Feb 2020 23:14:59 |
