Feature: ImageGPS
### Online Coordinate checker https://www.gps-coordinates.net/gps-coordinates-converter
Background: 
	Given I delete the folders
	| Path                           |
	| CheckTheImageHasGPSCoridinates |
	| GPSKeywords                    |

Scenario: CheckTheImageHasGPSCoridinates
	Given I copy the following files
	| SourceFolder | SourceFile | DestinationFolder              | DestinationFile |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates | GPS.jpg         |
	| JPG          | Good.jpg   | CheckTheImageHasGPSCoridinates | Good.jpg        |
	| JPG          | Bad.jpg    | CheckTheImageHasGPSCoridinates | Bad.jpg         |
	Then the following files have the values in the ImageFile object
	| TestFolder                     | TestFile | Longitude          | Latitude           | DegreesLongitude | DegreesLatitude   | ImageCreatedOriginal | ImageTaken           | GPSImageTaken        | DestinationFileName | KeyWords   |
	| CheckTheImageHasGPSCoridinates | GPS.jpg  | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | -5.35            | 36.11666666666667 | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     | Gibraltar; |
	| CheckTheImageHasGPSCoridinates | Good.jpg |                    |                    |                  |                   | 10 Mar 2018 11:53:53 | 10 Mar 2018 11:53:53 |                      | 20180310_115353     |            |
	| CheckTheImageHasGPSCoridinates | Bad.jpg  |                    |                    |                  |                   |                      |                      |                      |                     |            |

Scenario: GPSKeywords
	Given I create image objects with the following properties
	| Source       | TestFolder  | TestFile | Longitude           | Latitude             | ImageCreatedOriginal | GPSImageTaken        |  Keywords              |
	| JPG\Good.jpg | GPSKeywords | aaaa.jpg | 5.00°21.04'0.00" W  | 36.00°7.08'0.00" N   | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 |                        |
	| JPG\Good.jpg | GPSKeywords | bbbb.jpg | 5.00°21.04'0.00" W  | 36.00°7.08'0.00" N   | 27 Jan 2020 10:50:42 | 27 Jan 2020 12:50:41 |  BlueBell; Tinkerbell; |
	| JPG\Good.jpg | GPSKeywords | cccc.jpg | 4.00°8.00'37.392" W | 50.00°7.21'56.066" N | 27 Jan 2019 11:45:42 | 27 Jan 2019 13:45:42 |                        |
	| JPG\Good.jpg | GPSKeywords | dddd.jpg | 4.00°8.00'37.392" W | 50.00°7.21'56.066" N | 27 Jan 2019 12:45:42 | 27 Jan 2019 14:45:42 |  rain;snow;sun;        |
	| JPG\Good.jpg | GPSKeywords | eeee.jpg |                     |                      | 27 Jan 2020 16:50:41 |                      |                        |
	| JPG\Good.jpg | GPSKeywords | ffff.jpg |                     |                      | 27 Jan 2020 17:50:41 |                      |  rain;snow;sun;        |
	| JPG\Good.jpg | GPSKeywords | gggg.jpg |                     |                      | 27 Jan 2020 18:50:41 |                      |                        |
	| JPG\Good.jpg | GPSKeywords | hhhh.jpg |                     |                      | 27 Jan 2020 19:50:41 |                      |  BlueBell; Tinkerbell; |
	Then the image object list has following values
	| TestFile | Longitude           | Latitude             | DegreesLongitude | DegreesLatitude    | ImageCreatedOriginal | ImageTaken           | GPSImageTaken        | DestinationFileName | KeyWords                        |
	| aaaa.jpg | 5.00°21.04'0.00" W  | 36.00°7.08'0.00" N   | -5.35            | 36.11666666666667  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_095042     | Gibraltar;                      |
	| bbbb.jpg | 5.00°21.04'0.00" W  | 36.00°7.08'0.00" N   | -5.35            | 36.11666666666667  | 27 Jan 2020 10:50:42 | 27 Jan 2020 10:50:42 | 27 Jan 2020 12:50:41 | 20200127_105042     | BlueBell; Tinkerbell;Gibraltar; |
	| cccc.jpg | 4.00°8.00'37.392" W | 50.00°7.21'56.066" N | -4.14372         | 50.132240555555555 | 27 Jan 2019 11:45:42 | 27 Jan 2019 11:45:42 | 27 Jan 2019 01:45:42 | 20190127_114542     |                                 |
	| dddd.jpg | 4.00°8.00'37.392" W | 50.00°7.21'56.066" N | -4.14372         | 50.132240555555555 | 27 Jan 2019 12:45:42 | 27 Jan 2019 12:45:42 | 27 Jan 2019 02:45:42 | 20190127_124542     | rain;snow;sun;                  |
	| eeee.jpg |                     |                      |                  |                    | 27 Jan 2020 04:50:41 | 27 Jan 2020 04:50:41 |                      | 20200127_165041     |                                 |
	| ffff.jpg |                     |                      |                  |                    | 27 Jan 2020 05:50:41 | 27 Jan 2020 05:50:41 |                      | 20200127_175041     | rain;snow;sun;                  |
	| gggg.jpg |                     |                      |                  |                    | 27 Jan 2020 06:50:41 | 27 Jan 2020 06:50:41 |                      | 20200127_185041     |                                 |
	| hhhh.jpg |                     |                      |                  |                    | 27 Jan 2020 07:50:41 | 27 Jan 2020 07:50:41 |                      | 20200127_195041     | BlueBell; Tinkerbell;           |