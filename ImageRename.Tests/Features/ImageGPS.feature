Feature: ImageGPS

Background: 
	Given I delete the folders
	| Path                           |
	| CheckTheImageHasGPSCoridinates |

Scenario: CheckTheImageHasGPSCoridinates
	Given I copy the following files
	| SourceFolder | SourceFile | DestinationFolder              | DestinationFile |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates | GPS.jpg         |
	| JPG          | Good.jpg   | CheckTheImageHasGPSCoridinates | Good.jpg        |
	| JPG          | Bad.jpg    | CheckTheImageHasGPSCoridinates | Bad.jpg         |
	Then the following files have the values in the ImageFile object
	| TestFolder                     | TestFile | Longitude          | Latitude           | ImageCreatedOriginal | ImageTaken           | GPSImageTaken        | DestinationFileName | KeyWords |
	| CheckTheImageHasGPSCoridinates | GPS.jpg  | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     |          |
	| CheckTheImageHasGPSCoridinates | Good.jpg |                    |                    | 10 Mar 2018 11:53:53 | 10 Mar 2018 11:53:53 |                      | 20180310_115353     |          |
	| CheckTheImageHasGPSCoridinates | Bad.jpg  |                    |                    |                      |                      |                      |                     |          |

	