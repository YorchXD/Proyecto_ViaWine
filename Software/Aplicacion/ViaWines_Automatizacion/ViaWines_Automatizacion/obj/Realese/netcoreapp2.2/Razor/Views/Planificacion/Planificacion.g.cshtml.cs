#pragma checksum "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bb1c0aff0d3b26532e1cdac09309ea070eb53d8"
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
#line 1 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion;

#line default
#line hidden
#line 2 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bb1c0aff0d3b26532e1cdac09309ea070eb53d8", @"/Views/Planificacion/Planificacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Planificacion_Planificacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViaWines_Automatizacion.Models.Orden>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
  
    ViewData["Title"] = "Planificación";

#line default
#line hidden
            BeginContext(109, 132, true);
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <h1 calss=\"col-xs-12\">\r\n        Planificación\r\n        <small>Del día</small>\r\n    </h1>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
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
#line 26 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
    }

#line default
#line hidden
            BeginContext(926, 1135, true);
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
                                <th>Cant. Cajas</th>
                                <th>Fecha Fabricación</th>
                                <th>Hora de inicio</th>
                                <th>Hora de término</th>
                                <th>Estado");
            WriteLiteral("</th>\r\n                            </tr>\r\n                        </thead>\r\n\r\n                        <tbody>\r\n");
            EndContext();
#line 55 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                             if (Model != null)
                            {
                                

#line default
#line hidden
#line 57 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(2238, 132, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2371, 44, false);
#line 61 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Secuencia));

#line default
#line hidden
            EndContext();
            BeginContext(2415, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2555, 51, false);
#line 64 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.OrdenFabricacion));

#line default
#line hidden
            EndContext();
            BeginContext(2606, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2746, 42, false);
#line 67 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Version));

#line default
#line hidden
            EndContext();
            BeginContext(2788, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2928, 42, false);
#line 70 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Cliente));

#line default
#line hidden
            EndContext();
            BeginContext(2970, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(3110, 38, false);
#line 73 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.SKU));

#line default
#line hidden
            EndContext();
            BeginContext(3148, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(3288, 46, false);
#line 76 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(3334, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(3474, 55, false);
#line 79 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.BotellasPlanificadas));

#line default
#line hidden
            EndContext();
            BeginContext(3529, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(3669, 52, false);
#line 82 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.CajasPlanificadas));

#line default
#line hidden
            EndContext();
            BeginContext(3721, 141, true);
            WriteLiteral("\r\n                                        </td>\r\n\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(3863, 51, false);
#line 86 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.FechaFabricacion));

#line default
#line hidden
            EndContext();
            BeginContext(3914, 141, true);
            WriteLiteral("\r\n                                        </td>\r\n\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(4056, 56, false);
#line 90 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.HoraInicioPlanificada));

#line default
#line hidden
            EndContext();
            BeginContext(4112, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(4252, 57, false);
#line 93 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.HoraTerminoPlanificada));

#line default
#line hidden
            EndContext();
            BeginContext(4309, 97, true);
            WriteLiteral("\r\n                                        </td>\r\n\r\n                                        <td>\r\n");
            EndContext();
#line 97 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                              
                                                switch (item.Estado)
                                                {
                                                    case 0:

#line default
#line hidden
            BeginContext(4636, 110, true);
            WriteLiteral("                                                        <span class=\"label label-default\">No iniciado</span>\r\n");
            EndContext();
#line 102 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                        break;
                                                    case 1:

#line default
#line hidden
            BeginContext(4871, 109, true);
            WriteLiteral("                                                        <span class=\"label label-primary\">En proceso</span>\r\n");
            EndContext();
#line 105 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                        break;
                                                    case 2:

#line default
#line hidden
            BeginContext(5105, 104, true);
            WriteLiteral("                                                        <span class=\"label label-warning\">Pausa</span>\r\n");
            EndContext();
#line 108 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                        break;
                                                    case 3:

#line default
#line hidden
            BeginContext(5334, 107, true);
            WriteLiteral("                                                        <span class=\"label label-danger\">Pendiente</span>\r\n");
            EndContext();
#line 111 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                        break;
                                                    default:

#line default
#line hidden
            BeginContext(5567, 109, true);
            WriteLiteral("                                                        <span class=\"label label-success\">Finalizado</span>\r\n");
            EndContext();
#line 114 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                                        break;
                                                }
                                            

#line default
#line hidden
            BeginContext(5838, 90, true);
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 119 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                }

#line default
#line hidden
#line 119 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Planificacion\Planificacion.cshtml"
                                 
                            }

#line default
#line hidden
            BeginContext(5994, 279, true);
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
