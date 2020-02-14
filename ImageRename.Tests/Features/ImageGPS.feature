Feature: ImageGPS
### Online Coordinate checker https://www.gps-coordinates.net/gps-coordinates-converter
Background: 
	Given I delete the folders
	| Path                           |
	| CheckTheImageHasGPSCoridinates |
	| GPSKeywords                    |

Scenario: CheckTheImageHasGPSCoridinates
	Given I copy the following files
	| SourceFolder | SourceFile | DestinationFolder                         | DestinationFile |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates\Internet   | GPS.jpg         |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates\Internet   | GPS2.jpg        |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates\Internet   | GPS3.jpg        |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates\Internet   | GPS4.jpg        |
	| JPG          | Good.jpg   | CheckTheImageHasGPSCoridinates\Internet   | Good.jpg        |
	| JPG          | Good.jpg   | CheckTheImageHasGPSCoridinates\Internet   | Good2.jpg       |
	| JPG          | Bad.jpg    | CheckTheImageHasGPSCoridinates\Internet   | Bad.jpg         |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates\NoInternet | GPS.jpg         |
	| JPG          | GPS.jpg    | CheckTheImageHasGPSCoridinates\NoInternet | GPS2.jpg        |
	| JPG          | Good.jpg   | CheckTheImageHasGPSCoridinates\NoInternet | Good.jpg        |
	| JPG          | Good.jpg   | CheckTheImageHasGPSCoridinates\NoInternet | Good2.jpg       |
	| JPG          | Bad.jpg    | CheckTheImageHasGPSCoridinates\NoInternet | Bad.jpg         |

	And I add the keywords to the files
	| Filename                                            | Keywords          |
	| CheckTheImageHasGPSCoridinates\Internet\GPS2.jpg    | Green;Blue;       |
	| CheckTheImageHasGPSCoridinates\Internet\GPS3.jpg    | Gibraltar;        |
	| CheckTheImageHasGPSCoridinates\Internet\GPS4.jpg    | Gibraltar;Europe; |
	| CheckTheImageHasGPSCoridinates\Internet\Good2.jpg   | Red;Orange;       |
	| CheckTheImageHasGPSCoridinates\NoInternet\GPS2.jpg  | Green;Blue;       |
	| CheckTheImageHasGPSCoridinates\NoInternet\Good2.jpg | Red;Orange;       |
	Then the following files have the values in the ImageFile object
	| TestFolder                                | TestFile  | HasInternet | Longitude          | Latitude           | DegreesLongitude | DegreesLatitude   | ImageCreatedOriginal | ImageTaken           | GPSImageTaken        | DestinationFileName | KeyWords                     |
	| CheckTheImageHasGPSCoridinates\Internet   | GPS.jpg   | true        | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | -5.35            | 36.11666666666667 | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     | Gibraltar;Europe;            |
	| CheckTheImageHasGPSCoridinates\Internet   | GPS2.jpg  | true        | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | -5.35            | 36.11666666666667 | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     | Green;Blue;Gibraltar;Europe; |
	| CheckTheImageHasGPSCoridinates\Internet   | GPS3.jpg  | true        | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | -5.35            | 36.11666666666667 | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     | Gibraltar;Europe;            |
	| CheckTheImageHasGPSCoridinates\Internet   | GPS4.jpg  | true        | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | -5.35            | 36.11666666666667 | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     | Gibraltar;Europe;            |
	| CheckTheImageHasGPSCoridinates\Internet   | Good.jpg  | true        |                    |                    |                  |                   | 10 Mar 2018 11:53:53 | 10 Mar 2018 11:53:53 |                      | 20180310_115353     |                              |
	| CheckTheImageHasGPSCoridinates\Internet   | Good2.jpg | true        |                    |                    |                  |                   | 10 Mar 2018 11:53:53 | 10 Mar 2018 11:53:53 |                      | 20180310_115353     | Red;Orange;                  |
	| CheckTheImageHasGPSCoridinates\Internet   | Bad.jpg   | true        |                    |                    |                  |                   |                      |                      |                      |                     |                              |
	| CheckTheImageHasGPSCoridinates\NoInternet | GPS.jpg   | false       | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | -5.35            | 36.11666666666667 | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     |                              |
	| CheckTheImageHasGPSCoridinates\NoInternet | Good.jpg  | false       |                    |                    |                  |                   | 10 Mar 2018 11:53:53 | 10 Mar 2018 11:53:53 |                      | 20180310_115353     |                              |
	| CheckTheImageHasGPSCoridinates\NoInternet | GPS2.jpg  | false       | 5.00°21.04'0.00" W | 36.00°7.08'0.00" N | -5.35            | 36.11666666666667 | 27 Jan 2020 12:50:42 | 27 Jan 2020 11:50:41 | 27 Jan 2020 11:50:41 | 20200127_115041     | Green;Blue;                  |
	| CheckTheImageHasGPSCoridinates\NoInternet | Good2.jpg | false       |                    |                    |                  |                   | 10 Mar 2018 11:53:53 | 10 Mar 2018 11:53:53 |                      | 20180310_115353     | Red;Orange;                  |
	| CheckTheImageHasGPSCoridinates\NoInternet | Bad.jpg   | false       |                    |                    |                  |                   |                      |                      |                      |                     |                              |

Scenario: GPSKeywords
	Given I create image objects with the following properties
	| Source       | TestFolder  | HasInternet | TestFile | Longitude             | Latitude              | ImageCreatedOriginal | ImageTaken           | GPSImageTaken        | Keywords             |
	| JPG\Good.jpg | GPSKeywords | true        | aaaa.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 |                      |
	| JPG\Good.jpg | GPSKeywords | true        | bbbb.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | 27 Jan 2020 10:50:42 | 27 Jan 2020 10:50:42 | 27 Jan 2020 12:50:41 | BlueBell;Tinkerbell; |
	| JPG\Good.jpg | GPSKeywords | true        | cccc.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | 27 Jan 2019 11:45:42 | 27 Jan 2019 11:45:42 | 27 Jan 2019 13:45:42 |                      |
	| JPG\Good.jpg | GPSKeywords | true        | dddd.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | 27 Jan 2019 12:45:42 | 27 Jan 2019 12:45:42 | 27 Jan 2019 14:45:42 | rain;snow;sun;       |
	| JPG\Good.jpg | GPSKeywords | true        | eeee.jpg |                       |                       | 27 Jan 2020 16:50:41 | 27 Jan 2020 16:50:41 |                      |                      |
	| JPG\Good.jpg | GPSKeywords | true        | ffff.jpg |                       |                       | 27 Jan 2020 17:50:41 | 27 Jan 2020 17:50:41 |                      | rain;snow;sun;       |
	| JPG\Good.jpg | GPSKeywords | true        | gggg.jpg |                       |                       | 27 Jan 2020 18:50:41 | 27 Jan 2020 18:50:41 |                      |                      |
	| JPG\Good.jpg | GPSKeywords | true        | hhhh.jpg |                       |                       | 27 Jan 2020 19:50:41 | 27 Jan 2020 19:50:41 |                      | BlueBell;Tinkerbell; |
	| JPG\Good.jpg | GPSKeywords | false       | iiii.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 |                      |
	| JPG\Good.jpg | GPSKeywords | false       | jjjj.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | 27 Jan 2020 10:50:42 | 27 Jan 2020 10:50:42 | 27 Jan 2020 12:50:41 | BlueBell;Tinkerbell; |
	| JPG\Good.jpg | GPSKeywords | false       | kkkk.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | 27 Jan 2019 11:45:42 | 27 Jan 2019 11:45:42 | 27 Jan 2019 13:45:42 |                      |
	| JPG\Good.jpg | GPSKeywords | false       | llll.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | 27 Jan 2019 12:45:42 | 27 Jan 2019 12:45:42 | 27 Jan 2019 14:45:42 | rain;snow;sun;       |
	| JPG\Good.jpg | GPSKeywords | false       | mmmm.jpg |                       |                       | 27 Jan 2020 16:50:41 | 27 Jan 2020 16:50:41 |                      |                      |
	| JPG\Good.jpg | GPSKeywords | false       | nnnn.jpg |                       |                       | 27 Jan 2020 17:50:41 | 27 Jan 2020 17:50:41 |                      | rain;snow;sun;       |
	| JPG\Good.jpg | GPSKeywords | false       | oooo.jpg |                       |                       | 27 Jan 2020 18:50:41 | 27 Jan 2020 18:50:41 |                      |                      |
	| JPG\Good.jpg | GPSKeywords | false       | pppp.jpg |                       |                       | 27 Jan 2020 19:50:41 | 27 Jan 2020 19:50:41 |                      | BlueBell;Tinkerbell; |
	| JPG\Good.jpg | GPSKeywords | true        | qqqq.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | Gibraltar;           |
	| JPG\Good.jpg | GPSKeywords | true        | rrrr.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | Gibraltar;Europe;    |
	| JPG\Good.jpg | GPSKeywords | true        | ssss.jpg | 4.00°41.00'59.279" W  | 51.00°41.00'39.24" N  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 |                      |
	| JPG\Good.jpg | GPSKeywords | true        | tttt.jpg | 12.00°30.00'21.763" E | 55.00°52.00'25.54" N  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 |                      |
	| JPG\Good.jpg | GPSKeywords | true        | uuuu.jpg | 6.00°42.00'37.335" E  | 45.00°48.00'15.45" N  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 |                      |
	| JPG\Good.jpg | GPSKeywords | true        | vvvv.jpg | 9.00°52.00'4.4" E     | 53.00°33.00'38.652" N | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 |                      |


	Then the image object list has following values
	| TestFile | Longitude             | Latitude              | DegreesLongitude   | DegreesLatitude    | ImageCreatedOriginal | ImageTaken           | GPSImageTaken        | DestinationFileName | KeyWords                                                                 |
	| aaaa.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | -5.35              | 36.11666666666667  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     | Gibraltar;Europe;                                                        |
	| bbbb.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | -5.35              | 36.11666666666667  | 27 Jan 2020 10:50:42 | 27 Jan 2020 10:50:42 | 27 Jan 2020 12:50:41 | 20200127_125041     | BlueBell;Tinkerbell;Gibraltar;Europe;                                    |
	| cccc.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | -4.14372           | 50.132240555555555 | 27 Jan 2019 11:45:42 | 27 Jan 2019 11:45:42 | 27 Jan 2019 13:45:42 | 20190127_134542     |                                                                          |
	| dddd.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | -4.14372           | 50.132240555555555 | 27 Jan 2019 12:45:42 | 27 Jan 2019 12:45:42 | 27 Jan 2019 14:45:42 | 20190127_144542     | rain;snow;sun;                                                           |
	| eeee.jpg |                       |                       |                    |                    | 27 Jan 2020 16:50:41 | 27 Jan 2020 16:50:41 |                      | 20200127_165041     |                                                                          |
	| ffff.jpg |                       |                       |                    |                    | 27 Jan 2020 17:50:41 | 27 Jan 2020 17:50:41 |                      | 20200127_175041     | rain;snow;sun;                                                           |
	| gggg.jpg |                       |                       |                    |                    | 27 Jan 2020 18:50:41 | 27 Jan 2020 18:50:41 |                      | 20200127_185041     |                                                                          |
	| hhhh.jpg |                       |                       |                    |                    | 27 Jan 2020 19:50:41 | 27 Jan 2020 19:50:41 |                      | 20200127_195041     | BlueBell;Tinkerbell;                                                     |
	| iiii.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | -5.35              | 36.11666666666667  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     |                                                                          |
	| jjjj.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | -5.35              | 36.11666666666667  | 27 Jan 2020 10:50:42 | 27 Jan 2020 10:50:42 | 27 Jan 2020 12:50:41 | 20200127_125041     | BlueBell;Tinkerbell;                                                     |
	| kkkk.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | -4.14372           | 50.132240555555555 | 27 Jan 2019 11:45:42 | 27 Jan 2019 11:45:42 | 27 Jan 2019 13:45:42 | 20190127_134542     |                                                                          |
	| llll.jpg | 4.00°8.00'37.392" W   | 50.00°7.21'56.066" N  | -4.14372           | 50.132240555555555 | 27 Jan 2019 12:45:42 | 27 Jan 2019 12:45:42 | 27 Jan 2019 14:45:42 | 20190127_144542     | rain;snow;sun;                                                           |
	| mmmm.jpg |                       |                       |                    |                    | 27 Jan 2020 16:50:41 | 27 Jan 2020 16:50:41 |                      | 20200127_165041     |                                                                          |
	| nnnn.jpg |                       |                       |                    |                    | 27 Jan 2020 17:50:41 | 27 Jan 2020 17:50:41 |                      | 20200127_175041     | rain;snow;sun;                                                           |
	| oooo.jpg |                       |                       |                    |                    | 27 Jan 2020 18:50:41 | 27 Jan 2020 18:50:41 |                      | 20200127_185041     |                                                                          |
	| pppp.jpg |                       |                       |                    |                    | 27 Jan 2020 19:50:41 | 27 Jan 2020 19:50:41 |                      | 20200127_195041     | BlueBell;Tinkerbell;                                                     |
	| qqqq.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | -5.35              | 36.11666666666667  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     | Gibraltar;Europe;                                                        |
	| rrrr.jpg | 5.00°21.04'0.00" W    | 36.00°7.08'0.00" N    | -5.35              | 36.11666666666667  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     | Gibraltar;Europe;                                                        |
	| ssss.jpg | 4.00°41.00'59.279" W  | 51.00°41.00'39.24" N  | -4.699799722222222 | 51.69423333333333  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     | United Kingdom;Europe;Wales;Pembrokeshire;                               |
	| tttt.jpg | 12.00°30.00'21.763" E | 55.00°52.00'25.54" N  | 12.506045277777778 | 55.873761111111115 | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     | Denmark;Europe;Hørsholm;                                                 |
	| uuuu.jpg | 6.00°42.00'37.335" E  | 45.00°48.00'15.45" N  | 6.710370833333333  | 45.804291666666664 | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     | France;Europe;Les Contamines-Montjoie;Auvergne-Rhone-Alpes;Haute-Savoie; |
	| vvvv.jpg | 9.00°52.00'4.4" E     | 53.00°33.00'38.652" N | 9.867888888888888  | 53.56073666666666  | 27 Jan 2020 09:50:42 | 27 Jan 2020 09:50:42 | 27 Jan 2020 11:50:41 | 20200127_115041     | Germany;Europe;Hamburg;                                                  |