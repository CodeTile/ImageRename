Feature: ProcessFolder
	

Background: 
	Given I delete the folders
	| Path                                             |
	| ProcessFolderDontMoveTest                        |
	| ProcessFolderMoveTest                            |
	| ProcessFolderMoveTestProcessed                   |
	| ProcessFolderMoveTest2                           |
	| ProcessFolderMoveTest2Processed                  |
	| DuplicateTimeStampDontMove                       |
	| DuplicateTimeStampMove                           |
	| DuplicateTimeStampMoveProcessed                  |
	| DuplicateTimeStampMoveWithExistingFiles          |
	| DuplicateTimeStampMoveWithExistingFilesProcessed |

Scenario: DontMoveTest
	Given I create a copy of all test files into the folder 'ProcessFolderDontMoveTest'
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

Scenario: MoveTest1
	Given I create a copy of all test files into the folder 'ProcessFolderMoveTest'
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
	
	Scenario: MoveTest2
	Given I create a copy of all test files into the folder 'ProcessFolderMoveTest2'
	And in the folder 'ProcessFolderMoveTest2' I delete the files
	| Path         |
	| JPG\Bad.jpg |
	And the folder 'ProcessFolderMoveTest2' with subfolders contains
	| Path                     |
	| \CR2\20180408_122634.CR2 |
	| \CR2\Good.CR2            |
	| \JPG\Good.jpg            |
	| \JPG\GPS.jpg             |
	| \mov\20160124_141023.MOV |
	| \mov\Good.MOV            |
	| \mov\Good2.MOV           |
	| \NEF\20080601_020200.nef |
	| \NEF\Good.nef            |
	
	When I process the folder 'ProcessFolderMoveTest2' with the following flags
	| DebugDontRenameFile | MoveToProcessedByYear | ProcessedPath                   |
	| false               | true                  | ProcessFolderMoveTest2Processed |
	
	Then the folder 'ProcessFolderMoveTest2Processed' with subfolders contains
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
	And there are no subfolders in 'ProcessFolderMoveTest2'

Scenario: DuplicateTimeStampDontMove
	Given I create a copy of all test files into the folder 'DuplicateTimeStampDontMove'
	And I copy the following files in the folder 'DuplicateTimeStampDontMove'
         | SourceFolder | SourceFile | DestinationFolder | DestinationFile |
         | CR2          | good.cr2   | cr2               | Duplicate.cr2   |
         | jpg          | good.jpg   | jpg               | duplicate.jpg   |
         | JPG          | gps.jpg    | jpg               | Duplicate2.jpg  |
         | mov          | good.mov   | mov               | duplicate.Mov   |
	
	Then the folder 'DuplicateTimeStampDontMove' with subfolders contains
	| Path                     |
	| \CR2\20180408_122634.CR2 |
	| \CR2\Good.CR2            |
	| \JPG\Good.jpg            |
	| \JPG\GPS.jpg             |
	| \mov\20160124_141023.MOV |
	| \mov\Good.MOV            |
	| \mov\Good2.MOV           |
	| \NEF\20080601_020200.nef |
	| \NEF\Good.nef            |
	| \CR2\Duplicate.cr2       |
	| \JPG\Bad.jpg             |
	| \JPG\duplicate.jpg       |
	| \JPG\Duplicate2.jpg      |
	| \mov\duplicate.Mov       |
	
	When I process the folder 'DuplicateTimeStampDontMove' with the following flags
	| DebugDontRenameFile | MoveToProcessedByYear | ProcessedPath |
	| false               | false                 |               |
	Then the folder 'DuplicateTimeStampDontMove' with subfolders contains
	| Path                       |
	| \CR2\20180408_122634.CR2   |
	| \CR2\20180408_072740.cr2   |
	| \CR2\20180408_072740_2.CR2 |
	| \JPG\20180310_115353.jpg   |
	| \JPG\20180310_115353_2.jpg |
	| \JPG\20200127_115041.jpg   |
	| \JPG\20200127_115041_2.jpg |
	| \JPG\Bad.jpg               |
	| \mov\20151129_093543.MOV   |
	| \mov\20160124_141020.Mov   |
	| \mov\20160124_141020_2.MOV |
	| \mov\20160124_141023.MOV   |
	| \NEF\20080601_020200.nef   |
	| \NEF\20080601_020200_2.nef |

	Scenario: DuplicateTimeStampMoveWithExistingFiles
	Given I create a copy of all test files into the folder 'DuplicateTimeStampMoveWithExistingFiles'
	And I copy the following files in the folder 'DuplicateTimeStampMoveWithExistingFiles'
         | SourceFolder | SourceFile | DestinationFolder | DestinationFile |
         | CR2          | good.cr2   | cr2               | Duplicate.cr2   |
         | jpg          | good.jpg   | jpg               | duplicate.jpg   |
         | JPG          | gps.jpg    | jpg               | Duplicate2.jpg  |
         | mov          | good.mov   | mov               | duplicate.Mov   |
	And I copy the following files
        | SourceFolder | SourceFile          | DestinationFolder                                        | DestinationFile       |
        | CR2          | 20180408_122634.CR2 | DuplicateTimeStampMoveWithExistingFilesProcessed\2018\Q2 | 20180408_122634.CR2   |
        | CR2          | 20180408_122634.CR2 | DuplicateTimeStampMoveWithExistingFilesProcessed\2018\Q2 | 20180408_122634_2.CR2 |
	
	Then the folder 'DuplicateTimeStampMoveWithExistingFiles' with subfolders contains
	| Path                     |
	| \CR2\20180408_122634.CR2 |
	| \CR2\Good.CR2            |
	| \JPG\Good.jpg            |
	| \JPG\GPS.jpg             |
	| \mov\20160124_141023.MOV |
	| \mov\Good.MOV            |
	| \mov\Good2.MOV           |
	| \NEF\20080601_020200.nef |
	| \NEF\Good.nef            |
	| \CR2\Duplicate.cr2       |
	| \JPG\Bad.jpg             |
	| \JPG\duplicate.jpg       |
	| \JPG\Duplicate2.jpg      |
	| \mov\duplicate.Mov       |
	Then the folder 'DuplicateTimeStampMoveWithExistingFilesProcessed' with subfolders contains
	| Path                           |
	| \2018\Q2\20180408_122634.CR2   |
	| \2018\Q2\20180408_122634_2.CR2 |
	
	When I process the folder 'DuplicateTimeStampMoveWithExistingFiles' with the following flags
	| DebugDontRenameFile | MoveToProcessedByYear | ProcessedPath                                    |
	| false               | true                  | DuplicateTimeStampMoveWithExistingFilesProcessed |
	Then the folder 'DuplicateTimeStampMoveWithExistingFiles' with subfolders contains
	| Path         |
	| \JPG\Bad.jpg |
	And the folder 'DuplicateTimeStampMoveWithExistingFilesProcessed' with subfolders contains
	| Path                           |
	| \2008\Q2\20080601_020200.nef   |
	| \2008\Q2\20080601_020200_2.nef |
	| \2015\Q4\20151129_093543.MOV   |
	| \2016\Q1\20160124_141020.Mov   |
	| \2016\Q1\20160124_141020_2.MOV |
	| \2016\Q1\20160124_141023.MOV   |
	| \2018\Q1\20180310_115353.jpg   |
	| \2018\Q1\20180310_115353_2.jpg |
	| \2018\Q2\20180408_072740.cr2   |
	| \2018\Q2\20180408_072740_2.CR2 |
	| \2018\Q2\20180408_122634.CR2   |
	| \2020\Q1\20200127_115041.jpg   |
	| \2020\Q1\20200127_115041_2.jpg |
	| \2018\Q2\20180408_122634_2.CR2 |
	| \2018\Q2\20180408_122634_3.CR2 |
