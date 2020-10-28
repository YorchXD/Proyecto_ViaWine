#pragma checksum "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Resumen\Resumen.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3bb1a981d72b6113a1b2b179e3bccabeb7e25156"
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
#line 1 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion;

#line default
#line hidden
#line 2 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bb1a981d72b6113a1b2b179e3bccabeb7e25156", @"/Views/Resumen/Resumen.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Resumen_Resumen : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/cargando1.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("opacity:0.8; width:40%; height:30%; margin-top: 30%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/resumen.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Resumen\Resumen.cshtml"
  
    ViewData["Title"] = "Resumen";

#line default
#line hidden
            BeginContext(43, 976, true);
            WriteLiteral(@"

<section class=""content-header"">
    <h1>
        Resumen
        <small>Proceso actual</small>
    </h1>
</section>

<!-- Main content -->
<section class=""content resumen-actual"">

    <!--Resumen del proceso actual-->

    <div class=""row"">

        <div class=""form-group col-lg-6 col-md-6 col-sm-12 col-xs-12"">
            <div class=""datepicker"">
                <div class=""input-group date"">
                    <div class=""input-group-addon"">
                        <i class=""fa fa-calendar""></i>
                    </div>
                    <input type=""text"" class=""form-control pull-right"" id=""datepicker"" name=""fecha"" autocomplete=""off"" onchange=""buscarPlanificacion()"">
                </div>
            </div>
        </div>

        <div class=""form-group col-lg-6 col-md-6 col-sm-12 col-xs-12"">
            <select class=""form-control select2"" style=""width: 100%;"" id=""numeroOrden"" onchange=""mostrarOrden()"">
                ");
            EndContext();
            BeginContext(1019, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3bb1a981d72b6113a1b2b179e3bccabeb7e251566501", async() => {
                BeginContext(1056, 20, true);
                WriteLiteral("Seleccione una orden");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1085, 13333, true);
            WriteLiteral(@"
            </select>
        </div>
    </div>

    <div class=""row"">

        <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
            
            <p>
                <dl class=""dl-horizontal"" style=""color:white"">
                    <dt>Cliente</dt>
                    <dd id=""cliente"">-</dd>
                    <dt>SKU</dt>
                    <dd id=""SKU"">-</dd>
                    <dt>N° de prioridad</dt>
                    <dd id=""secuencia"">-</dd>
                    <dt>Cantidad de botellas planificadas</dt>
                    <dd id=""cantBotellasPlan"">-</dd>
                    <dt>Cantidad de cajas planificada</dt>
                    <dd id=""cantCajasPlan"">-</dd>
                    <dt>Estado</dt>
                    <dd id=""estado"">-</dd>
                    <dt>Fecha de fabricación</dt>
                    <dd id=""fechaPlan"">-</dd>
                    <dt>Formato de caja</dt>
                    <dd id=""formatoCaja"">-</dd>
                </dl>
         ");
            WriteLiteral(@"   </p>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-lg-12 text-right"">
            <p style=""color:white;"">Última actualización: <span id=""horaActualizacionIndicadoresOrden"">--:--</span>hrs</p>
        </div>
        <div class=""col-md-4 col-sm-6 col-xs-12"">
            <div class=""info-box bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-thumbs-o-up""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Botellas contabilizadas</span>
                    <span class=""info-box-number"" id=""cantBotellas"">-</span>

                    <div class=""progress"" id=""progresoBotellas"">
                        <!--div class=""progress-bar"" style=""width: 70%""></div-->
                    </div>
                    <span class=""progress-description"" id=""porcentBotellas"">-% de avance</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box");
            WriteLiteral(@" -->
        </div>
        <!-- ./col -->

        <div class=""col-md-4 col-sm-6 col-xs-12"">
            <div class=""info-box bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-bookmark-o""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Cajas contabilizadas</span>
                    <span class=""info-box-number"" id=""cantCajas"">-</span>

                    <div class=""progress"" id=""progresoCajas"">
                        <!--div class=""progress-bar"" style=""width: 70%""></div-->
                    </div>
                    <span class=""progress-description"" id=""porcentCajas"">
                        -% de avance
                    </span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->

        <div class=""col-md-4 col-sm-12 col-xs-12"">
            <div class=""info-box bg-gray"">
                <");
            WriteLiteral(@"span class=""info-box-icon""><i class=""fa fa-bookmark-o""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Botellas equivalentes</span>
                    <span class=""info-box-number"" id=""cantBotellasEquiv"">-</span>

                    <div class=""progress"" id=""progresoBotellasEquiv"">
                        <!--div class=""progress-bar"" style=""width: 70%""></div-->
                    </div>
                    <span class=""progress-description"" id=""porcentBotellasEquiv"">
                        -% de avance
                    </span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->

        <div class=""col-md-6 col-sm-6 col-xs-12"">
            <div class=""info-box"">
                <span class=""info-box-icon""><i class=""fa fa-star-o""></i></span>

                <div class=""info-box-content"">
                    <span clas");
            WriteLiteral(@"s=""info-box-text"">Cantidad de botella por minuto</span>
                    <span class=""info-box-number"" id=""cantBotellasMin"">-</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->
        <div class=""col-md-6 col-sm-6 col-xs-12"">
            <div class=""info-box"">
                <span class=""info-box-icon""><i class=""fa fa-files-o""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Cantidad de cajas por minuto</span>
                    <span class=""info-box-number"" id=""cantCajasMin"">-</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->
    </div>
    <!-- /.row -->
    <!-- Main row -->
    <div class=""row"">
        <section class=""col-xs-12 connectedSortable"">
            <!-- Custom tabs (Charts with tabs)");
            WriteLiteral(@"-->
            <div class=""nav-tabs-custom"">
                <!-- Tabs within a box -->
                <ul class=""nav nav-tabs pull-right"">
                    <li class=""pull-left header""><i class=""fa fa-inbox""></i> Cantidad de botellas y cajas por minuto</li>
                </ul>

                <div id=""chartdiv1""></div>

                <div class=""tab-content no-padding"">


                </div>
            </div>
            <!-- /.nav-tabs-custom -->
        </section>
        <!-- Left col -->
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
        <div class=""col-lg-12 text-right"">
            <p style=""color:black;"">Última actualización: <span id=""horaActualizacionIndicadoresDia"">--:--</span>hrs</p>
        </div>
        <div class=""col-md-3 col-sm-6 col-xs-12"">
          ");
            WriteLiteral(@"  <div class=""info-box bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-thumbs-o-up""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Botellas contabilizadas</span>
                    <span class=""info-box-number"" id=""cantBotellasDia"">-</span>

                    <div class=""progress"" id=""progresoBotellasDia"">
                        <!--div class=""progress-bar"" style=""width: 15%""></div-->
                    </div>
                    <span class=""progress-description"" id=""porcentBotellasDia"">-% de avance</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->

        <div class=""col-md-3 col-sm-6 col-xs-12"">
            <div class=""info-box bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-bookmark-o""></i></span>

                <div class=""info-box-content"">
                  ");
            WriteLiteral(@"  <span class=""info-box-text"">Cajas contabilizadas</span>
                    <span class=""info-box-number"" id=""cantCajasDia"">-</span>

                    <div class=""progress"" id=""progresoCajasDia"">
                        <!--div class=""progress-bar"" style=""width: 70%""></div-->
                    </div>
                    <span class=""progress-description"" id=""porcentCajasDia"">-% de avance</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->

        <div class=""col-md-3 col-sm-6 col-xs-12"">
            <div class=""info-box bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-calendar""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Ordenes Finalizadas</span>
                    <span class=""info-box-number"" id=""cantOrdenesDia"">-</span>

                    <div class=""progress"" id=""progresoOrdenesD");
            WriteLiteral(@"ia"">
                        <!--div class=""progress-bar"" style=""width: 0%""></div-->
                    </div>
                    <span class=""progress-description"" id=""porcentOrdenesDia"">-% de avance</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->

        <div class=""col-md-3 col-sm-6 col-xs-12"">
            <div class=""info-box bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-comments-o""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Avance por hora</span>
                    <span class=""info-box-number"" id=""porcentajePorHora"">-%</span>

                    <!--span class=""info-box-number"">30</span-->

                    <div class=""progress"" id=""progresoPorHora"">
                        <!--div class=""progress-bar"" style=""width: 5%""></!div-->
                    </div>
               ");
            WriteLiteral(@"     <span class=""progress-description"" id=""horaPorcentaje"">Hora del avance: --:--</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
    </div>

    <div class=""row"">
        <section class=""col-xs-12 connectedSortable"">
            <!-- Custom tabs (Charts with tabs)-->
            <div class=""nav-tabs-custom"">
                <!-- Tabs within a box -->
                <ul class=""nav nav-tabs pull-right"">
                    <li class=""pull-left header""><i class=""fa fa-inbox""></i> Cantidad de botellas y cajas por hora</li>
                </ul>
                <div class=""tab-content no-padding"">
                    <!-- Morris chart - Sales -->
                    <!--div class=""chart tab-pane active"" id=""revenue-chart"" style=""position: relative; height: 300px;""></div-->
                    <div id=""chartdiv2""></div>
                </div>
            </div>
            <!-");
            WriteLiteral(@"- /.nav-tabs-custom -->
        </section>
        <!-- /.Left col -->
    </div>

    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""box"">
                <div class=""box-header with-border"">
                    <h3 class=""box-title"">Resumen de ordenes</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""tabla"" class=""table table-bordered display dt-responsive"" cellspacing=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Prioridad</th>
                                <th>Orden</th>
                                <th>Cliente</th>
                                <th>Fecha de fabricación</th>
                                <th>Estado</th>
                                <th>Progreso</th>
                                <th style=""width: 40px"">% del progreso</th>
                            </tr>
             ");
            WriteLiteral(@"           </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class=""modal fade"" id=""modal-alerta"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-red"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"" id=""title-alert""></h4>
                </div>
                <div class=""modal-body"">
                    <p id=""body-alert""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn bg-black"" data-dismiss=""modal"">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <div clas");
            WriteLiteral(@"s=""modal fade"" id=""modal-confirm"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-purple"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"" id=""title-confirm""></h4>
                </div>
                <div class=""modal-body"">
                    <p id=""body-confirm""></p>
                </div>
                <div class=""modal-footer"">
                    <button id=""btnConfirm"" type=""button"" class=""btn bg-black"" data-dismiss=""modal"">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <div id=""myModal"" class=""modalFP"" style=""display: none;"">
        <!-- Modal content -->
        <div class=""modal-cont");
            WriteLiteral("entFP\">\r\n            ");
            EndContext();
            BeginContext(14418, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3bb1a981d72b6113a1b2b179e3bccabeb7e2515622682", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(14512, 1571, true);
            WriteLiteral(@"
        </div>
    </div>
    <!-- /.modal -->
</section>

<style>
    .event a {
        background-color: #560f3d !important;
        color: #ffffff !important;
    }
    .modalFP {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 100000; /* Sit on top */
        padding-top: 150px; /* Location of the box */
        padding-bottom: 150px;
        left: 0;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgba(0,0,0, 0.4); /* Fallback color */
        background-color: rgba(0,0,0,0.8); /* Black w/ opacity */
    }

    /* Modal Content */
    .modal-contentFP {
        background: url(""~/../../img/tenor.gif"") no-repeat;
        background-color: rgba(254,254,254,0.4);
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 340px;
        height: 340px;
    ");
            WriteLiteral(@"    text-align: center;
        border-radius: 30px;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
    }
</style>

<script src=""https://unpkg.com/moment""></script>
<!--   Datatables-->
<script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.10.20/datatables.min.js""></script>
<!-- extension responsive -->
<script src=""https://cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js""></script>
<!--Acciones para las ordenes e indicadores-->
");
            EndContext();
            BeginContext(16083, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3bb1a981d72b6113a1b2b179e3bccabeb7e2515625551", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(16145, 847, true);
            WriteLiteral(@"

<!-- Graficos -->
<script src=""https://www.amcharts.com/lib/4/core.js""></script>
<script src=""https://www.amcharts.com/lib/4/charts.js""></script>
<script src=""https://www.amcharts.com/lib/4/themes/dataviz.js""></script>
<script src=""https://www.amcharts.com/lib/4/themes/animated.js""></script>

<script>
    $(document).ready(function ()
    {
        fechasOrdenes();
        buscarPlanificacion();
        document.getElementById(""horaActualizacionIndicadoresOrden"").innerHTML = obtenerHora();
        document.getElementById(""horaActualizacionIndicadoresDia"").innerHTML = obtenerHora();
        $.fn.DataTable.ext.pager.numbers_length = 5;
    });
</script>

<style>
    #chartdiv1 {
        width: 100%;
        height: 350px;
    }

    #chartdiv2 {
        width: 100%;
        height: 350px;
    }
</style>

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
