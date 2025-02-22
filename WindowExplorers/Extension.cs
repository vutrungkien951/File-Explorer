﻿using System;
using System.Collections.Generic;
using System.Text;
//{"aaa", "aaa" },
namespace WindowExplorers
{
    class Extension
    {
        public static Dictionary<string, string> typeFile = new Dictionary<string, string>()
        {
            {"aac", "Windows audio file"},
            {"adt", "Windows audio file"},
            {"adts", "Windows audio file"},
            {"accdb", "Microsoft Access database file" },
            {"accde", "Microsoft Access execute-only file" },
            {"accdr", "Microsoft Access runtime database" },
            {"accdt", "Microsoft Access database template" },
            {"aif", "Audio Interchange File format file" },
            {"aifc", "Audio Interchange File format file" },
            {"aiff", "Audio Interchange File format file" },
            {"aspx", "ASP.NET Active Server page" },
            {"avi", "Audio Video Interleave movie or sound file" },
            {"bat", "PC batch file" },
            {"bin", "Binary compressed file" },
            {"bmp", "Bitmap file" },
            {"cab", "Windows Cabinet file" },
            {"cda", "CD Audio Track" },
            {"csv", "Comma-separated values file" },
            {"dif", "Spreadsheet data interchange format file" },
            {"dll", "Dynamic Link Library file" },
            {"doc", "Microsoft Word document before Word 2007" },
            {"docm", "Microsoft Word macro-enabled document" },
            {"docx", "Microsoft Word document" },
            {"dot", "Microsoft Word template before Word 2007" },
            {"dotx", "Microsoft Word template" },
            {"eml", "Email file created by Outlook Express, Windows Live Mail, and other programs" },
            {"eps", "Encapsulated Postscript file" },
            {"exe", "Executable program file" },
            {"flv", "Flash-compatible video file" },
            {"gif", "Graphical Interchange Format file" },
            {"htm", "Hypertext markup language page" },
            {"html", "Hypertext markup language page" },
            {"ini", "Windows initialization configuration file" },
            {"iso", "ISO-9660 disc image" },
            {"jar", "Java architecture file" },
            {"jpg", "Joint Photographic Experts Group photo file" },
            {"jpeg", "Joint Photographic Experts Group photo file" },
            {"m4a", "MPEG-4 audio file" },
            {"mdb", "Microsoft Access database before Access 2007" },
            {"mid", "Musical Instrument Digital Interface file" },
            {"midi", "Musical Instrument Digital Interface file" },
            {"mov", "Apple QuickTime movie file" },
            {"mp3", "MPEG layer 3 audio file" },
            {"mp4", "MPEG 4 video" },
            {"mpeg", "Moving Picture Experts Group movie file" },
            {"mpg", "MPEG 1 system stream" },
            {"msi", "Microsoft installer file" },
            {"mui", "Multilingual User Interface file" },
            {"pdf", "Portable Document Format file" },
            {"png", "Portable Network Graphics file" },
            {"pot", "Microsoft PowerPoint template before PowerPoint 2007" },
            {"potm", "Microsoft PowerPoint macro-enabled template" },
            {"potx", "Microsoft PowerPoint template" },
            {"ppam", "Microsoft PowerPoint add-in" },
            {"pps", "Microsoft PowerPoint slideshow before PowerPoint 2007" },
            {"ppsm", "Microsoft PowerPoint macro-enabled slideshow" },
            {"ppsx", "Microsoft PowerPoint slideshow" },
            {"ppt", "Microsoft PowerPoint format before PowerPoint 2007" },
            {"pptm", "Microsoft PowerPoint macro-enabled presentation" },
            {"pptx", "Microsoft PowerPoint presentation" },
            {"psd", "Adobe Photoshop file" },
            {"pst", "Outlook data store" },
            {"pub", "Microsoft Publisher file" },
            {"rar", "Roshal Archive compressed file" },
            {"rtf", "Rich Text Format file" },
            {"sldm", "Microsoft PowerPoint macro-enabled slide" },
            {"sldx", "Microsoft PowerPoint slide" },
            {"swf", "Shockwave Flash file" },
            {"sys", "Microsoft DOS and Windows system settings and variables file" },
            {"tif", "Tagged Image Format file" },
            {"tiff", "Tagged Image Format file" },
            {"tmp", "Temporary data file" },
            {"txt", "Unformatted text file" },
            {"vob", "Video object file" },
            {"vsd", "Microsoft Visio drawing before Visio 2013" },
            {"vsdm", "Microsoft Visio macro-enabled drawing" },
            {"vsdx", "Microsoft Visio drawing file" },
            {"vss", "Microsoft Visio stencil before Visio 2013" },
            {"vssm", "Microsoft Visio macro-enabled stencil" },
            {"vst", "Microsoft Visio template before Visio 2013" },
            {"vstm", "Microsoft Visio macro-enabled template" },
            {"vstx", "Microsoft Visio template" },
            {"wav", "Wave audio file" },
            {"wbk", "Microsoft Word backup document" },
            {"wks", "Microsoft Works file" },
            {"wma", "Windows Media Audio file" },
            {"wmd", "Windows Media Download file" },
            {"wmv", "Windows Media Video file" },
            {"wmz", "Windows Media skins file" },
            {"wms", "Windows Media skins file" },
            {"wpd", "WordPerfect document" },
            {"wp5", "WordPerfect document" },
            {"xla", "Microsoft Excel add-in or macro file" },
            {"xlam", "Microsoft Excel add-in after Excel 2007" },
            {"xll", "Microsoft Excel DLL-based add-in" },
            {"xlm", "Microsoft Excel macro before Excel 2007" },
            {"xls", "Microsoft Excel workbook before Excel 2007" },
            {"xlsm", "Microsoft Excel macro-enabled workbook after Excel 2007" },
            {"xlsx", "Microsoft Excel workbook after Excel 2007" },
            {"xlt", "Microsoft Excel template before Excel 2007" },
            {"xltm", "Microsoft Excel macro-enabled template after Excel 2007" },
            {"xltx", "Microsoft Excel template after Excel 2007" },
            {"xps", "XML-based document" },
            {"zip", "Compressed file" }
        };

        public static String getType(string key)
        {
            if (typeFile.ContainsKey(key))
            {
                return typeFile[key];
            }
            return null;
        }

        private static Dictionary<string, int> indexImageFile = new Dictionary<string, int>()
        {
            {"", 0 },
        };

        
    }
}
