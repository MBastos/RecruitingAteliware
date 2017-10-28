(function ($) {
    "use strict";

    var repositorios = $("#Repositorios");
    var carregarRepositorios = function (linguagem) {    
        var url = "https://api.github.com/search/repositories?q=language:" + linguagem +"&sort=stars&order=desc&page=1&per_page=5";
        $.get(url, function (data) {                                                
            if (table) {
                table.destroy();
            }

            alunosDatatable(data.items);         
        });
    };

    $("#Linguagem")
        .on("change", function (event) {
            event.preventDefault();     
            if(this.value !== "") {
                carregarRepositorios(this.value);
            }               
                
        });         

    var table = null;
    var dataTable = $("#datatable-repositorios");    
    var alunosDatatable = function (repositorios) {            
        table = dataTable
                    .DataTable({
                            processing: true,
                            responsive: true,  
                            paging: false,
                            searching: false,
                            aaData: repositorios,   
                            bSort: false,
                            bInfo : false,
                            stateSave: true,                            
                            columns: [                                
                                { data: 'id', class: "text-center" },
                                { data: 'name', class: "text-center"},
                                { data: "stargazers_count", class: "text-center"},
                                { data: 'description', class: "text-justify" }
                            ]
                    });        
    }    
    
    alunosDatatable("");
})($ || jQuery);

