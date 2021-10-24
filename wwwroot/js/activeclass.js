$('.btn-active').on('click', function(){
    $(this).siblings().removeClass('active').css("color","#00ACED"); // if you want to remove class from all sibling buttons
    $(this).toggleClass('active').css("color","#00ACED","background","#ccc");
});