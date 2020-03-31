#pragma checksum "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abf175608d7ec8a79bbdf0deefde5a9b81c1cdb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Planificacion_Planificacion), @"mvc.1.0.view", @"/Views/Planificacion/Planificacion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Planificacion/Planificacion.cshtml", typeof(AspNetCore.Views_Planificacion_Planificacion))]
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
#line 1 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion;

#line default
#line hidden
#line 2 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abf175608d7ec8a79bbdf0deefde5a9b81c1cdb3", @"/Views/Planificacion/Planificacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Planificacion_Planificacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViaWines_Automatizacion.Models.Orden>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
  
    ViewData["Title"] = "Planificación";

#line default
#line hidden
            BeginContext(109, 132, true);
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <h1 calss=\"col-xs-12\">\r\n        Planificación\r\n        <small>Del día</small>\r\n    </h1>\r\n\r\n");
            EndContext();
#line 13 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
     using (Html.BeginForm("Planificacion", "Planificacion", FormMethod.Post, new { @style = "border:none" }))
    {

#line default
#line hidden
            BeginContext(360, 559, true);
            WriteLiteral(@"        <div class=""datepicker-in-title"">
            <div class=""input-group date input-group-sm"" style=""width: 200px;"">
                <div class=""input-group-addon"">
                    <i class=""fa fa-calendar""></i>
                </div>
                <input type=""text"" class=""form-control pull-right"" id=""datepicker"" name=""fecha"">
                <div class=""input-group-btn"">
                    <button type=""submit"" class=""btn btn-default""><i class=""fa fa-search""></i></button>
                </div>
            </div>
        </div>
");
            EndContext();
#line 26 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
    }

#line default
#line hidden
            BeginContext(926, 1322, true);
            WriteLiteral(@"    </section>

<!-- Main content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box"">
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""tabla"" class=""table table-bordered table-striped table-hover"">
                        <thead>
                            <tr>
                                <th>Secuencia</th>
                                <th>Orden</th>
                                <th>Version</th>
                                <th>Cliente</th>
                                <th>SKU</th>
                                <th>Descripción</th>
                                <th>Cant. Botellas</th>
                                <th>Cant. Botellas Fabricadas</th>
                                <th>Cant. Cajas</th>
                                <th>Cant. Cajas Fabricadas</th>
                                <th>Fecha Fabricación</th>
                        ");
            WriteLiteral(@"        <th>Hora de inicio</th>
                                <th>Hora de término</th>
                                <th>Estado</th>
                                <th>% de avance</th>
                            </tr>
                        </thead>

                        <tbody>
");
            EndContext();
#line 58 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                             if (Model != null)
                            {
                                

#line default
#line hidden
#line 60 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(2425, 108, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2534, 44, false);
#line 64 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Secuencia));

#line default
#line hidden
            EndContext();
            BeginContext(2578, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2694, 51, false);
#line 67 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.OrdenFabricacion));

#line default
#line hidden
            EndContext();
            BeginContext(2745, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2861, 42, false);
#line 70 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Version));

#line default
#line hidden
            EndContext();
            BeginContext(2903, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3019, 42, false);
#line 73 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Cliente));

#line default
#line hidden
            EndContext();
            BeginContext(3061, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3177, 38, false);
#line 76 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.SKU));

#line default
#line hidden
            EndContext();
            BeginContext(3215, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3331, 46, false);
#line 79 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(3377, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3493, 55, false);
#line 82 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.BotellasPlanificadas));

#line default
#line hidden
            EndContext();
            BeginContext(3548, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3664, 53, false);
#line 85 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.BotellasFabricadas));

#line default
#line hidden
            EndContext();
            BeginContext(3717, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3833, 52, false);
#line 88 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CajasPlanificadas));

#line default
#line hidden
            EndContext();
            BeginContext(3885, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(4001, 50, false);
#line 91 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CajasFabricadas));

#line default
#line hidden
            EndContext();
            BeginContext(4051, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(4167, 51, false);
#line 94 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FechaFabricacion));

#line default
#line hidden
            EndContext();
            BeginContext(4218, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(4336, 56, false);
#line 98 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.HoraInicioPlanificada));

#line default
#line hidden
            EndContext();
            BeginContext(4392, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(4508, 57, false);
#line 101 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                               Write(Html.DisplayFor(modelItem => item.HoraTerminoPlanificada));

#line default
#line hidden
            EndContext();
            BeginContext(4565, 81, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n");
            EndContext();
#line 105 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                      
                                        switch (item.Estado)
                                        {
                                            case 0:

#line default
#line hidden
            BeginContext(4844, 102, true);
            WriteLiteral("                                                <span class=\"label label-default\">No iniciado</span>\r\n");
            EndContext();
#line 110 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            case 1:

#line default
#line hidden
            BeginContext(5055, 101, true);
            WriteLiteral("                                                <span class=\"label label-primary\">En proceso</span>\r\n");
            EndContext();
#line 113 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            case 2:

#line default
#line hidden
            BeginContext(5265, 96, true);
            WriteLiteral("                                                <span class=\"label label-warning\">Pausa</span>\r\n");
            EndContext();
#line 116 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            case 3:

#line default
#line hidden
            BeginContext(5470, 99, true);
            WriteLiteral("                                                <span class=\"label label-danger\">Pendiente</span>\r\n");
            EndContext();
#line 119 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            default:

#line default
#line hidden
            BeginContext(5679, 101, true);
            WriteLiteral("                                                <span class=\"label label-success\">Finalizado</span>\r\n");
            EndContext();
#line 122 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                        }
                                    

#line default
#line hidden
            BeginContext(5918, 77, true);
            WriteLiteral("                                </td>\r\n                                <td>\r\n");
            EndContext();
#line 127 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                      
                                        switch (item.Estado)
                                        {
                                            case 0:

#line default
#line hidden
            BeginContext(6193, 82, true);
            WriteLiteral("                                                <span class=\"label label-default\">");
            EndContext();
            BeginContext(6276, 51, false);
#line 131 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                                             Write(Html.DisplayFor(modelItem => item.PorcentajeAvance));

#line default
#line hidden
            EndContext();
            BeginContext(6327, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 132 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            case 1:

#line default
#line hidden
            BeginContext(6445, 82, true);
            WriteLiteral("                                                <span class=\"label label-primary\">");
            EndContext();
            BeginContext(6528, 51, false);
#line 134 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                                             Write(Html.DisplayFor(modelItem => item.PorcentajeAvance));

#line default
#line hidden
            EndContext();
            BeginContext(6579, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 135 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            case 2:

#line default
#line hidden
            BeginContext(6697, 82, true);
            WriteLiteral("                                                <span class=\"label label-warning\">");
            EndContext();
            BeginContext(6780, 51, false);
#line 137 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                                             Write(Html.DisplayFor(modelItem => item.PorcentajeAvance));

#line default
#line hidden
            EndContext();
            BeginContext(6831, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 138 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            case 3:

#line default
#line hidden
            BeginContext(6949, 81, true);
            WriteLiteral("                                                <span class=\"label label-danger\">");
            EndContext();
            BeginContext(7031, 51, false);
#line 140 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                                            Write(Html.DisplayFor(modelItem => item.PorcentajeAvance));

#line default
#line hidden
            EndContext();
            BeginContext(7082, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 141 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                            default:

#line default
#line hidden
            BeginContext(7201, 82, true);
            WriteLiteral("                                                <span class=\"label label-success\">");
            EndContext();
            BeginContext(7284, 51, false);
#line 143 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                                             Write(Html.DisplayFor(modelItem => item.PorcentajeAvance));

#line default
#line hidden
            EndContext();
            BeginContext(7335, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 144 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                break;
                                        }
                                    

#line default
#line hidden
            BeginContext(7482, 74, true);
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 149 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                }

#line default
#line hidden
#line 149 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                 
                            }

#line default
#line hidden
            BeginContext(7622, 279, true);
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</section>
<!-- /.content -->

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ViaWines_Automatizacion.Models.Orden>> Html { get; private set; }
    }
}
#pragma warning restore 1591
