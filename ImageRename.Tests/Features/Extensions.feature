Feature: Extensions
	Test the extensions in ImageRename.Standard
	### Online Coordinate checker https://www.gps-coordinates.net/gps-coordinates-converter
@mytag
Scenario: CoordinatesToDegrees
Given I test the coordinates
| Coordinates        | Degrees   | KeyWords                                                                         |
| 36.00°7.08'0.00" N | 36.11667  | Camp Bay, Gibraltar                                                              |
| 5.00°21.04'0.00" W | -5.35000  | Camp Bay, Gibraltar                                                              |
| 25°20′42″S         | -25.34500 | Uluru, Base Walk South, Mutitjulu NT, Australia                                  |
| 131°02′10″E        | 131.03611 | Uluru, Base Walk South, Mutitjulu NT, Australia                                  |
| 50° 39' 45.62" N   | 50.66267  | The Needles Lighthouse, T25, Alum Bay PO39 0JH, United Kingdom                   |
| 1° 35' 21.124" W   | -1.58920  | The Needles Lighthouse, T25, Alum Bay PO39 0JH, United Kingdom                   |
| 53° 32' 30.44"n    | 53.54179  | St. Pauli-Elbtunnel, 20457 Hamburg, Germany                                      |
| 9° 57' 59.653"e    | 9.96657   | St. Pauli-Elbtunnel, 20457 Hamburg, Germany                                      |
| 15° 52' 2.8"s      | -15.86744 | Sagres, Estrada Parque Aeroporto, Lago Sul - Federal District, 70610-100, Brazil |  
| 47° 55' 52.345"w   | -47.93121 | Sagres, Estrada Parque Aeroporto, Lago Sul - Federal District, 70610-100, Brazil |