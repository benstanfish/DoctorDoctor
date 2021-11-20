# DoctorDoctor (Version 1.1.4)
### Download .msi for Direct Install
Currently in development, the purpose of DoctorDoctor is to provide an improved user experience for reviewing Dr. Checks comments. After saving Dr. Checks comments from ProjNet as a XML file, this app cleans the XML, then loads it into a Treeview list, which uses text and background colors to identify the history and status of all comments.

This application doesn't currently have write functionality (by design) -- it's intended to be a viewer.

### Architecture Notes

The class structure and IO file operations are not exactly ideal, but they are the way they due to the oddities of the XML formatting that is exported from ProjNet. While valid, there are some structural issues that have to be accounted for on import.
