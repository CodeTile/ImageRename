Feature: ImageGPS

	
Scenario: CheckTheImageHasGPSCoridinates
	Given I clear the testfiles folder
	And I copy the following files
	| SourceFolder | SourceFile | DestinationFolder | DestinationFile |
	| JPG          | GPS.jpg    | GPSTest           | GPS.jpg         |
	| JPG          | Good.jpg   | GPSTest           | Good.jpg        |
	| JPG          | Bad.jpg    | GPSTest           | Bad.jpg         |
	Then the following files have the values in the ImageFile object
	| TestFolder | TestFile | Longitude          | Latitude           | ImageCreatedOriginal | ImageTaken           | GPSImageTaken        |
	| GPSTest    | GPS.jpg  | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 |
	| GPSTest    | Good.jpg |                    |                    | 10 Mar 2018 11:53:53 | 10 Mar 2018 11:53:53 |                      |
	| GPSTest    | Bad.jpg  |                    |                    |                      |                      |                      |