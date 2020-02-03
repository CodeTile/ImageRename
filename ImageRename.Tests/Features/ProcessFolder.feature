﻿Feature: ProcessFolder
	

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
	#And I process the folder 'ProcessFolderDontMoveTest' with the following flags
	#| DebugDontRenameFile | MoveToProcessedByYear | ProcessedPath |
	#| false               | false                 |               |

