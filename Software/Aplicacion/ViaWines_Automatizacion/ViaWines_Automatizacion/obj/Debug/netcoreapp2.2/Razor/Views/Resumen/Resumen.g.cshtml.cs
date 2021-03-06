#pragma checksum "D:\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Resumen\Resumen.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7dc190b85732249c24cd91992c2ba0e63dcb6884"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resumen_Resumen), @"mvc.1.0.view", @"/Views/Resumen/Resumen.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Resumen/Resumen.cshtml", typeof(AspNetCore.Views_Resumen_Resumen))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion;

#line default
#line hidden
#line 2 "D:\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc190b85732249c24cd91992c2ba0e63dcb6884", @"/Views/Resumen/Resumen.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Resumen_Resumen : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Resumen\Resumen.cshtml"
  
    ViewData["Title"] = "Resumen";

#line default
#line hidden
            BeginContext(43, 12205, true);
            WriteLiteral(@"

<section class=""content-header"">
    <h1>
        Resumen
        <small>Proceso actual</small>
    </h1>
</section>

<!-- Main content -->
<section class=""content"">

    <!--Resumen del proceso actual-->
    <div class=""row"">
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-aqua"">
                <div class=""inner"">
                    <br>
                    <h3>150</h3>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-bag""></i>
                </div>
                <p class=""small-box-footer"">Cajas finalizadas</p>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-green"">
                <div class=""inner"">
                    <br>
                    <h3>53<sup style=""font-size: 20px"">%</sup></h3>
                </div>
                <div class=""ico");
            WriteLiteral(@"n"">
                    <i class=""ion ion-stats-bars""></i>
                </div>
                <p class=""small-box-footer""> Botellas finalizadas</p>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-yellow"">
                <div class=""inner"">
                    <br>
                    <h3>44</h3>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-person-add""></i>
                </div>
                <p class=""small-box-footer""> Cantidad de cajas por minuto</p>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-red"">
                <div class=""inner"">
                    <br>
                    <h3>65</h3>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-pi");
            WriteLiteral(@"e-graph""></i>
                </div>
                <p class=""small-box-footer"">Cantidad de botella por minuto</p>
            </div>
        </div>
        <!-- ./col -->
    </div>
    <!-- /.row -->
    <!-- Main row -->
    <div class=""row"">
        <!-- Left col -->
        <section class=""col-xs-12 connectedSortable"">
            <!-- Custom tabs (Charts with tabs)-->
            <div class=""nav-tabs-custom"">
                <!-- Tabs within a box -->
                <ul class=""nav nav-tabs pull-right"">
                    <li class=""pull-left header""><i class=""fa fa-inbox""></i> Sales</li>
                </ul>
                <div class=""tab-content no-padding"">
                    <!-- Morris chart - Sales -->
                    <div class=""chart tab-pane active"" id=""revenue-chart"" style=""position: relative; height: 300px;""></div>
                    <div class=""chart tab-pane"" id=""sales-chart"" style=""position: relative; height: 300px;""></div>
                </div>
          ");
            WriteLiteral(@"  </div>
            <!-- /.nav-tabs-custom -->

        </section>
        <!-- /.Left col -->
        <!-- right col (We are only adding the ID to make the widgets sortable)-->
        <section class=""col-lg-5 connectedSortable"" style=""display: none"">

            <!-- Map box -->
            <div class=""box box-solid bg-light-blue-gradient"">
                <div class=""box-header"">
                    <!-- tools box -->
                    <div class=""pull-right box-tools"">
                        <button type=""button"" class=""btn btn-primary btn-sm daterange pull-right"" data-toggle=""tooltip""
                                title=""Date range"">
                            <i class=""fa fa-calendar""></i>
                        </button>
                        <button type=""button"" class=""btn btn-primary btn-sm pull-right"" data-widget=""collapse""
                                data-toggle=""tooltip"" title=""Collapse"" style=""margin-right: 5px;"">
                            <i class=""fa fa-minu");
            WriteLiteral(@"s""></i>
                        </button>
                    </div>
                    <!-- /. tools -->

                    <i class=""fa fa-map-marker""></i>

                    <h3 class=""box-title"">
                        Visitors
                    </h3>
                </div>
                <div class=""box-body"">
                    <div id=""world-map"" style=""height: 250px; width: 100%;""></div>
                </div>
                <!-- /.box-body-->
                <div class=""box-footer no-border"">
                    <div class=""row"">
                        <div class=""col-xs-4 text-center"" style=""border-right: 1px solid #f4f4f4"">
                            <div id=""sparkline-1""></div>
                            <div class=""knob-label"">Visitors</div>
                        </div>
                        <!-- ./col -->
                        <div class=""col-xs-4 text-center"" style=""border-right: 1px solid #f4f4f4"">
                            <div id=""sparkline-2""></d");
            WriteLiteral(@"iv>
                            <div class=""knob-label"">Online</div>
                        </div>
                        <!-- ./col -->
                        <div class=""col-xs-4 text-center"">
                            <div id=""sparkline-3""></div>
                            <div class=""knob-label"">Exists</div>
                        </div>
                        <!-- ./col -->
                    </div>
                    <!-- /.row -->
                </div>
            </div>
            <!-- /.box -->
        </section>
        <!-- right col -->
    </div>
    <!-- /.row (main row) -->
</section>



<section class=""content-header"">
    <h1>
        Resumen
        <small>Del día</small>
    </h1>
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-lg-4 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-aqua"">
                <div class=""inner"">
                    <br>
        ");
            WriteLiteral(@"            <h3>150</h3>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-bag""></i>
                </div>
                <p class=""small-box-footer"">Ordenes finalizadas</p>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-4 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-green"">
                <div class=""inner"">
                    <br>
                    <h3>53<sup style=""font-size: 20px"">%</sup></h3>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-stats-bars""></i>
                </div>
                <p class=""small-box-footer""> Cajas Finalizadas</p>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-4 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-yellow"">
                <div class=""inner"">
                    <br>
                    <h3>44</h3>
 ");
            WriteLiteral(@"               </div>
                <div class=""icon"">
                    <i class=""ion ion-person-add""></i>
                </div>
                <p class=""small-box-footer""> Botellas Finalizadas</p>
            </div>
        </div>
    </div>

    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box"">
                <div class=""box-header"">
                    <h3 class=""box-title"">Bordered Table</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table class=""table table-bordered"">
                        <tr>
                            <th>Prioridad</th>
                            <th>Orden</th>
                            <th>Cliente</th>
                            <th>Estado</th>
                            <th>Progreso</th>
                            <th style=""width: 40px"">% del progres0</th>
                        </tr>
                        <tr>
                 ");
            WriteLiteral(@"           <td>5462649</td>
                            <td>1</td>
                            <td>Good Price Corporation S.A.S.</td>
                            <td><span class=""label label-success"">Finalizada</span></td>
                            <td>
                                <div class=""progress progress-xs progress-striped active"">
                                    <div class=""progress-bar progress-bar-success"" style=""width: 100%""></div>
                                </div>
                            </td>
                            <td><span class=""badge bg-green"">100%</span></td>
                        </tr>

                        <tr>
                            <td>3254698</td>
                            <td>2</td>
                            <td>Good Price Corporation S.A.S.</td>
                            <td><span class=""label label-danger"">Rechazada</span></td>
                            <td>
                                <div class=""progress progress-xs"">");
            WriteLiteral(@"
                                    <div class=""progress-bar progress-bar-danger"" style=""width: 55%""></div>
                                </div>
                            </td>
                            <td><span class=""badge bg-red"">55%</span></td>
                        </tr>

                        <tr>
                            <td>1234567</td>
                            <td>3</td>
                            <td>Good Price Corporation S.A.S.</td>
                            <td><span class=""label label-primary"">En proceso</span></td>
                            <td>
                                <div class=""progress progress-xs progress-striped active"">
                                    <div class=""progress-bar progress-bar-primary"" style=""width:75%""></div>
                                </div>
                            </td>
                            <td><span class=""badge bg-light-blue"">75%</span></td>
                        </tr>

                        <tr>
");
            WriteLiteral(@"                            <td>3278541</td>
                            <td>4</td>
                            <td>Good Price Corporation S.A.S.</td>
                            <td><span class=""label label-warning"">Pendiente</span></td>
                            <td>
                                <div class=""progress progress-xs progress-striped active"">
                                    <div class=""progress-bar progress-bar-yellow"" style=""width: 0%""></div>
                                </div>
                            </td>
                            <td><span class=""badge bg-yellow"">0%</span></td>
                        </tr>

                        <tr>
                            <td>2647826</td>
                            <td>5</td>
                            <td>Good Price Corporation S.A.S.</td>
                            <td><span class=""label label-warning"">Pendiente</span></td>
                            <td>
                                <div class=""progress p");
            WriteLiteral(@"rogress-xs progress-striped active"">
                                    <div class=""progress-bar progress-bar-yellow"" style=""width: 0%""></div>
                                </div>
                            </td>
                            <td><span class=""badge bg-yellow"">0%</span></td>
                        </tr>


                    </table>
                </div>
                <!-- /.box-body -->
                <div class=""box-footer clearfix"">
                    <ul class=""pagination pagination-sm no-margin pull-right"">
                        <li><a href=""#"">&laquo;</a></li>
                        <li><a href=""#"">1</a></li>
                        <li><a href=""#"">2</a></li>
                        <li><a href=""#"">3</a></li>
                        <li><a href=""#"">&raquo;</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</section>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
