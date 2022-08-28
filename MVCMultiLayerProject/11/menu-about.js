function menuAbout(){
    document.getElementById("site-navigation").classList.toggle("show");
}

window.onclick = function(event){
    if(!event.target.matches('.menu-toggle')){
    var dropdown = document.getElementsByClassName("main-navigation clear");
    var i;
    for(i=0; i < dropdown.length; i++){
        var openDropdown = dropdown[i];
        if(openDropdown.classList.contains('show')){
            openDropdown.classList.remove('show');
        }
    }
}
}