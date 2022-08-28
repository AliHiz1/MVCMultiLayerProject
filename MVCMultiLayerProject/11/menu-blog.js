function menuBlog(){
    document.getElementById("site-navigation").classList.toggle("show");
}

window.onclick = function(event){
    if(!event.target.matches('.stick-menu-toggle')){
    var dropdown = document.getElementsByClassName("stick-main-nav clear");
    var i;
    for(i=0; i < dropdown.length; i++){
        var openDropdown = dropdown[i];
        if(openDropdown.classList.contains('show')){
            openDropdown.classList.remove('show');
        }
    }
}
}