tinyMCEPopup.requireLangPack();

var WikiDialog = {
init: function() {

	},
	insert: function() {
		// Insert the contents from the input into the document
		var output = '';
		var form = document.forms[0];
		if ($.trim(form.AutoCompleteSearchTextbox.value) != '' && form.pageLinkText.value != '') {

			if (form.ddlSpace.value > 0) {

				output = '[[' + form.ddlSpace.value + '|' + form.AutoCompleteSearchTextbox.value + '|' + form.pageLinkText.value + ']]';
			}
			else {
				output = '[[' + form.AutoCompleteSearchTextbox.value + '|' + form.pageLinkText.value + ']]';
			}
		}
		else if ($.trim(form.AutoCompleteSearchTextbox.value) != '') {
			if (form.ddlSpace.value > 0) {
				output = '[[' + form.ddlSpace.value + '|' + form.AutoCompleteSearchTextbox.value + '|' + form.AutoCompleteSearchTextbox.value + ']]';
			}
			else {
				output = '[[' + form.AutoCompleteSearchTextbox.value +'|'+ form.AutoCompleteSearchTextbox.value + ']]';
			}
		}

		tinyMCEPopup.editor.execCommand('mceInsertContent', false, output);
		tinyMCEPopup.close();
	}

}

function start() {

	var spaceID = 0;
	var noOfRecords = 20;
	var docForm=document.forms[0]
	var ddlSpace = docForm.ddlSpace;
	if (ddlSpace != null || ddlSpace != undefined) {
		var spaceID = ddlSpace.value;
	}
	$(ddlSpace).change(function() {
		$("input#AutoCompleteSearchTextbox").unbind();
		$("input#AutoCompleteSearchTextbox").autocomplete('../../../../../JsonResources/GetTopics.aspx?spaceID=' + document.forms[0].ddlSpace.value + '&noOfRecords=' + noOfRecords, {
			width: 310,
			matchContains: true,
			autoFill: true
		});

	});
	
	
	$("input#AutoCompleteSearchTextbox").autocomplete('../../../../../JsonResources/GetTopics.aspx?spaceID=' + spaceID + '&noOfRecords=' + noOfRecords, {
    	width: 310,
    	matchContains: true,
    	autoFill: true
    });

}
tinyMCEPopup.onInit.add(WikiDialog.init, WikiDialog);
tinyMCEPopup.executeOnLoad("start()");

