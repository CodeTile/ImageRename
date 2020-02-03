Feature: ProcessFolder
	

Background: 
	Given I clear the testfiles folder

Scenario: DontMoveTest
	Given I create a copy of all test files in the folder 'ProcessFolderDontMoveTest'
	And the folder 'ProcessFolderDontMoveTest' with subfolders contains
	| Path                     |
	| \CR2\20180408_122634.CR2 |
	| \CR2\Good.CR2            |
	| \JPG\Bad.jpg             |
	| \JPG\Good.jpg            |
	| \JPG\GPS.jpg             |
	| \mov\20160124_141023.MOV |
	| \mov\Good.MOV            |
	| \mov\Good2.MOV           |
	| \NEF\20080601_020200.nef |
	| \NEF\Good.nef            |

	When I process the folder 'ProcessFolderDontMoveTest' with the following flags
	| DebugDontRenameFile | MoveToProcessedByYear | ProcessedPath |
	| false               | false                 |               |
	
	Then the folder 'ProcessFolderDontMoveTest' with subfolders contains
	| Path                       |
	| \CR2\20180408_072740.CR2   |
	| \CR2\20180408_122634.CR2   |
	| \JPG\20180310_115353.jpg   |
	| \JPG\Bad.jpg               |
	| \JPG\20200127_115041.jpg   |
	| \mov\20151129_093543.MOV   |
	| \mov\20160124_141020.MOV   |
	| \mov\20160124_141023.MOV   |
	| \NEF\20080601_020200.nef   |
	| \NEF\20080601_020200_2.nef |

Scenario: MoveTest
	Given I create a copy of all test files in the folder 'ProcessFolderMoveTest'
	And the folder 'ProcessFolderMoveTest' with subfolders contains
	| Path                     |
	| \CR2\20180408_122634.CR2 |
	| \CR2\Good.CR2            |
	| \JPG\Bad.jpg             |
	| \JPG\Good.jpg            |
	| \JPG\GPS.jpg             |
	| \mov\20160124_141023.MOV |
	| \mov\Good.MOV            |
	| \mov\Good2.MOV           |
	| \NEF\20080601_020200.nef |
	| \NEF\Good.nef            |
	
	When I process the folder 'ProcessFolderMoveTest' with the following flags
	| DebugDontRenameFile | MoveToProcessedByYear | ProcessedPath                     |
	| false               | true                  | ProcessFolderMoveTestProcessed |
	
	Then the folder 'ProcessFolderMoveTestProcessed' with subfolders contains
	| Path                           |
	| \2008\Q2\20080601_020200.nef   |
	| \2008\Q2\20080601_020200_2.nef |
	| \2015\Q4\20151129_093543.MOV   |
	| \2016\Q1\20160124_141020.MOV   |
	| \2016\Q1\20160124_141023.MOV   |
	| \2018\Q1\20180310_115353.jpg   |
	| \2018\Q2\20180408_072740.CR2   |
	| \2018\Q2\20180408_122634.CR2   |
	| \2020\Q1\20200127_115041.jpg   |
	And the folder 'ProcessFolderMoveTest' with subfolders contains
	| Path         |
	| \JPG\Bad.jpg |
	And the folder 'ProcessFolderMoveTest' has subfolders
	| Path |
	| \JPG |