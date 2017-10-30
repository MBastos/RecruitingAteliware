(function ($) {
    "use strict";

    var urlApiGitHub = "https://api.github.com/search/repositories?sort=stars&order=desc&page=1&per_page=5",
        repositorios = $("#Repositorios"),
        linguagem = $("#Linguagem");

    var carregarRepositorios = function (linguagem) {    
        var url = urlApiGitHub + "&q=language:" + linguagem ;
        $.get(url, function (data) {                                                
            if (table) {
                table.destroy();
            }

            alunosDatatable(data.items);         
        });
    };

    linguagem
        .on("change", function (event) {
            event.preventDefault();     
            if(this.value !== "") {
                carregarRepositorios(this.value);
            }               
                
        });         

    var table = null;
    var dataTable = $("#datatable-repositorios");    
    var reps = null;
    var alunosDatatable = function (repositorios) {            
        reps = repositorios;
        //$("#Repositorios").val(repositorios);
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
                            language: {
                                url: "js/DataTables.PT-BR.json"
                            },
                            columnDefs: [     
                            {
                                targets: 2,
                                data: 'owner',
                                render: function (data) {
                                    return "<a href=" + data.html_url + " target='_blank'>" +  data.login + "</a>";
                                }
                            },
                            {
                                targets: 3,
                                data: 'created_at',
                                render: function (data) {
                                    return moment(data).format('DD/MM/YYYY HH:mm:ss');
                                }
                            },
                            {
                                targets: 4,
                                data: 'updated_at',
                                render: function (data) {
                                    return moment(data).format('DD/MM/YYYY HH:mm:ss');
                                }
                            }],
                            columns: [   
                                {
                                    "className":      'details-control',
                                    "orderable":      false,
                                    "data":           null,
                                    "defaultContent": ''
                                },                                                             
                                { data: 'name', class: "text-center"},                                
                                { data: "owner", class: "text-center"},
                                { data: "created_at", class: "text-center"},                                
                                { data: "updated_at", class: "text-center"}                                
                            ]
                    });        
    }    
    
    alunosDatatable("");
    
    var formatarDescricao = function(repositorio){
        return "<div class='text-justify'>"+ repositorio.description + "</td>";
    }    
    
    dataTable
        .find("tbody")
        .on("click", "td.details-control", function () {
            var tr = $(this).closest("tr");
            var row = table.row( tr );
    
            if ( row.child.isShown() ) {                
                row.child.hide();
                tr.removeClass("shown");
            }
            else {                
                row.child( formatarDescricao(row.data()) ).show();
                tr.addClass("shown");
            }
        });

        $('#btnSalvar')
            .on("click", function (e) {
                var x = JSON.stringify({
                    reps
                });                                              
                $.ajax({
                    type: "post",                    
                    url: baseUrl("Home/Salvar"),
                    dataType: "json",        
                    //contentType: 'application/json',
                    ContentType: 'application/json;utf-8',
                    traditional: true,
                    data:{
                        "linguagem": linguagem.val(),
                        "repositorios" : x.reps
                    },                    
                    error: function (response) {                        
                        alert(response.responseText);
                    },
                    success: function (response) {
                        alert(response.responseText);
                    }
                });
            });
})($ || jQuery);

