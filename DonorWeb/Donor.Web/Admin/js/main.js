$(function(){
    $(".main-menu > li > a").click(function (e) {
        // Added By Vikash On 26-Jun-2014 : Which Menu has not child menu then e.preventDefault is not occure

        if ($(this).hasClass("test")) {
            e.preventDefault();
        }
        //e.preventDefault();
		if($(this).hasClass("expanded"))
		{
			$(this).removeClass("expanded");
			$(this).parent().children("ul").stop(true,true).slideUp("normal");
		}
		else
		{
			$(".main-menu a.expanded").removeClass("expanded");
			$(this).addClass("expanded");
			$(".sub-items").filter(":visible").slideUp("normal");
			$(this).parent().children("ul").stop(true,true).slideDown("normal");    
		}
	});


    $(".sub-items a").click(function(){
		$(".has-sub a").removeClass("current");
		$(this).addClass("current");
	});

});