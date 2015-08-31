	 function  Save_Button_onclick() {



	 var lang = document.getElementById("ProgrammingLangauges").value;
	 var code = WrapCode(lang);
	 var rawcode = document.getElementById("CodeArea").value;
	 var formattedcode =  rawcode.replace(/</g, '&lt;').replace(/>/g, '&gt;');
	 code = code + formattedcode + "</pre><br> ";

     if (document.getElementById("CodeArea").value == ''){
		tinyMCEPopup.close();
		return false;
	}
	tinyMCEPopup.execCommand('mceInsertContent', false, code);
	tinyMCEPopup.close();
    }
    
    function  WrapCode(lang)
    {
       var options = "";
       if (document.getElementById("nogutter").checked == true)
           options = "; gutter:false";
       
       if (document.getElementById("collapse").checked == true)
       options = options + ":collapse";
              
       if (document.getElementById("nocontrols").checked == true)
       options = options + ":nocontrols";
              
       if (document.getElementById("showcolumns").checked == true)
       options = options + ":showcolumns";
       
        return "<pre class='brush:"+lang+ options+ "'>";
    }

    function Cancel_Button_onclick()
    {
    	    tinyMCEPopup.close();
    	    return false;
    }
