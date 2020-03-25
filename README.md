# 3. Programming excercise

## Usage
Driver program in fileReaderUI.

run: 
```
dotnet run --project fileReaderUI/fileReaderUI.csproj
```
to launch the application.

Program asks for:
- path to a file
- file extension
- encryption (reverse)
- role base security
- role (if role base security) 

## Supported files

Program supports files of type .txt, .xml, and .json. Other file types are rejected by the program.
Dummy files are available for tests:
- files/file.txt
- files/file.xml
- files/file.json

## Encrypted files

Program supports decryption of files. The dummy decryption algorithm reverses the encrypted files.
Dummy files are available for tests:
- files/file_encrypted.txt
- files/file_encrypted.xml
- files/file_encrypted.json

## Role base security

Program supports role base security for granting read access to files.
Dummy roles available in the program:
- admin -> can read all files
- member -> cannot read files containing *admin* in title
  
Dummy files are available for tests:
- files/file_admin.txt
- files/file_admin.xml
- files/file_admin.json