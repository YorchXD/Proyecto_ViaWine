#pragma checksum "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcf4d4572d4a2d7f1d7b57826172a141fd52ea21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proceso_Proceso), @"mvc.1.0.view", @"/Views/Proceso/Proceso.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Proceso/Proceso.cshtml", typeof(AspNetCore.Views_Proceso_Proceso))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcf4d4572d4a2d7f1d7b57826172a141fd52ea21", @"/Views/Proceso/Proceso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Proceso_Proceso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViaWines_Automatizacion.Models.Orden>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/proceso.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
  
    ViewData["Title"] = "Proceso";


#line default
#line hidden
            BeginContext(105, 340, true);
            WriteLiteral(@"


<section class=""content-header"">
    <div class="""">
        <h1>
            Proceso
            <small>del pedido</small>
        </h1>
    </div>
    <div class=""row"">
        <div class=""col-xs-12 col-md-6"">
            <select class=""form-control select2"" id=""numeroOrden"" onchange=""seleccionarOrden()"">
                ");
            EndContext();
            BeginContext(445, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcf4d4572d4a2d7f1d7b57826172a141fd52ea215238", async() => {
                BeginContext(482, 20, true);
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
            BeginContext(511, 12346, true);
            WriteLiteral(@"
            </select>
        </div>
    </div>
</section>

<section class=""content"">
    <div class=""row"">
        <div class=""col-md-3 col-sm-6 col-xs-12"">
            <div class=""info-box bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-thumbs-o-up""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Botellas finalizadas</span>
                    <span class=""info-box-number"" id=""cantBotellas"">-</span>

                    <div class=""progress"" id=""progresoBotellas"">
                        <!--div class=""progress-bar"" style=""width: 70%""></div-->
                    </div>
                    <span class=""progress-description"" id=""porcentBotellas"">-% de avance</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->

        <div class=""col-md-3 col-sm-6 col-xs-12"">
            <div class=""info-bo");
            WriteLiteral(@"x bg-gray"">
                <span class=""info-box-icon""><i class=""fa fa-bookmark-o""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Cajas finalizadas</span>
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
        <div class=""col-md-3 col-sm-6 col-xs-12"">
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
        <div class=""col-md-3 col-sm-6 col-xs-12"">
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
    <!-- Small boxes (Stat box) -->
    <!--div class=""row"">

    </div-->
    <!-- /.row -->

    <div class=""row"">
        <div class=""col-");
            WriteLiteral(@"lg-3 col-md-4 col-sm-4 col-xs-6"">
            <p>
                <button type=""button"" id=""btnInicio"" class=""btn btn-block bg-purple"">Inicio</button>
            </p>
            <p>
                <button type=""button"" id=""btnPausar"" class=""btn btn-block bg-orange"">Pausar</button>
            </p>
            <p>
                <button type=""button"" id=""btnPosponer"" class=""btn btn-block bg-maroon"">Posponer</button>
            </p>
            <p>
                <button type=""button"" id=""btnFinalizar"" class=""btn btn-block bg-olive"">Terminar</button>
            </p>
        </div>
        <!-- ./col -->

        <div class=""col-lg-9 col-md-8 col-sm-8 col-xs-6"">
            <div class=""box box-solid"">
                <div class=""box-header with-border"">
                    <i class=""fa fa-text-width""></i>
                    <h3 class=""box-title"">Descripción de la orden</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
        ");
            WriteLiteral(@"            <dl class=""dl-horizontal"">
                        <dt>SKU</dt>
                        <dd id=""SKU""></dd>
                        <dt>Descripción del producto</dt>
                        <dd id=""descripcionProducto""></dd>
                        <dt>Cantidad de cajas planificadas</dt>
                        <dd id=""cantCajasPlan""></dd>
                        <dt>Cantidad de botellas planificadas</dt>
                        <dd id=""cantBotellasPlan""></dd>
                        <dt>Hora de inicio planificada</dt>
                        <dd id=""horaInicioPlan""></dd>
                        <dt>Hora de término planificada</dt>
                        <dd id=""horaTerminoPlan""></dd>
                        <dt>Fecha planificada</dt>
                        <dd id=""fechaPlan""></dd>
                        <dt>Estado</dt>
                        <dd id=""estado""></dd>

                    </dl>
                </div>
                <!-- /.box-body -->
            </div>
     ");
            WriteLiteral(@"       <!-- /.box -->
        </div>
        <!-- ./col -->

    </div>



    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""box"">
                <div class=""box-header with-border"">
                    <h3 class=""box-title"">Monitoreo de etiquetado de botellas</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""tablaBotellas"" class=""table table-bordered display dt-responsive"" cellpadding=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th style=""width: 10px"">#</th>
                                <th>Fecha y hora de término</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
            <!-- /.box -->
        </div>
        <!-- /.col -->

        <div class=""col-md-6"">
            <div class=""box"">
             ");
            WriteLiteral(@"   <div class=""box-header with-border"">
                    <h3 class=""box-title"">Monitoreo de cajas</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""tablaCajas"" class=""table table-bordered display dt-responsive"" cellspacing=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th style=""width: 10px"">#</th>
                                <th>Fecha y hora de término</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
            <!-- /.box -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->

    <div class=""modal fade"" id=""modal-inicio"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-purple"">
                    <button type=""button"" class=""close"" data-dismis");
            WriteLiteral(@"s=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"" id=""title-ini-process""></h4>
                </div>
                <div class=""modal-body"">
                    <p id=""body-ini-process""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" id=""btnInicioProceso"" class=""btn bg-black"">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <div class=""modal fade"" id=""modal-pausar"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-orange"">
                    <button type=""button"" class=""close"" data-dismiss=""m");
            WriteLiteral(@"odal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"" id=""title-pause-process""></h4>
                </div>
                <div class=""modal-body"">
                    <p id=""body-pause-process""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" id=""btnPausarProceso"" class=""btn bg-black"">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <div class=""modal fade"" id=""modal-posponer"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-maroon"">
                    <button type=""button"" class=""close"" data-dismiss=");
            WriteLiteral(@"""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"" id=""title-postpone-process""></h4>
                </div>
                <div class=""modal-body"">
                    <p id=""body-postpone-process""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" id=""btnPosponerProceso"" class=""btn bg-black"">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <div class=""modal fade"" id=""modal-finalizar"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-olive"">
                    <button type=""button"" class=""close"" dat");
            WriteLiteral(@"a-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"" id=""title-finalize-process""></h4>
                </div>
                <div class=""modal-body"">
                    <p id=""body-finalize-process""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" id=""btnFinalizarProceso"" class=""btn bg-black"">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->



    <div class=""modal fade"" id=""modal-alerta"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-red"">
                    <button type=""button"" class=""cl");
            WriteLiteral(@"ose"" data-dismiss=""modal"" aria-label=""Close"">
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
</section>


<!--script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script-->
<script src=""https://unpkg.com/moment""></script>
<!--   Datatables-->
<script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.10.20/datatables.min.js""></script>
<!-- extension responsive -->
<script src=""https://cdn.datatables.net/res");
            WriteLiteral("ponsive/2.2.3/js/dataTables.responsive.min.js\"></script>\r\n");
            EndContext();
            BeginContext(12857, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcf4d4572d4a2d7f1d7b57826172a141fd52ea2120390", async() => {
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
            BeginContext(12919, 70, true);
            WriteLiteral("\r\n\r\n<script>\r\n    function seleccionarOrden() {\r\n        var modelo = ");
            EndContext();
            BeginContext(12990, 97, false);
#line 332 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model, Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(13087, 724, true);
            WriteLiteral(@";
        mostrarOrden(modelo);
    }
</script>

<script>
    $('#btnInicio').click(function () { exist_proces_ini(1); });
    $('#btnInicioProceso').click(function () { Actualizar_Estado(1); });
    $('#btnPausar').click(function () { exist_proces_ini(2); });
    $('#btnPausarProceso').click(function () { Actualizar_Estado(2); });
    $('#btnPosponer').click(function () { exist_proces_ini(3); });
    $('#btnPosponerProceso').click(function () { Actualizar_Estado(3); });
    $('#btnFinalizar').click(function () { exist_proces_ini(4); });
    $('#btnFinalizarProceso').click(function () { Actualizar_Estado(4); });
</script>



<script>
    $(document).ready(function ()
    {
        var modelo = ");
            EndContext();
            BeginContext(13812, 96, false);
#line 353 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model,Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(13908, 554, true);
            WriteLiteral(@";
        iniciarOrdenesSelect(modelo);
        $.fn.DataTable.ext.pager.numbers_length = 4;
    });
</script>

<script>
    function actualizarTablasMonitoreo()
    {
        /*var ordenSelect = document.getElementById(""numeroOrden"");
        var cajasPlan = document.getElementById(""cantCajasPlan"");
        var botellasPlan = document.getElementById(""cantBotellasPlan"");
        var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
        irMonitoreo(numeroOrden, botellasPlan, cajasPlan);*/


        var modelo = ");
            EndContext();
            BeginContext(14463, 97, false);
#line 369 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model, Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(14560, 1248, true);
            WriteLiteral(@";
        var ordenSelect = document.getElementById(""numeroOrden"");
        var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
        for (var i = 0; modelo!=null && i < modelo.length; i++) {
            if (modelo[i][""Estado""] == 1 && numeroOrden == modelo[i][""OrdenFabricacion""]) {
                monitoreo(numeroOrden, modelo[i][""BotellasPlanificadas""], modelo[i][""CajasPlanificadas""])
                break;
            }
        }




        //for (var i = 0; modelo!=null && i < modelo.length; i++) {
            //if (modelo[i][""Estado""] == 1 && numeroOrden == modelo[i][""OrdenFabricacion""])
            //{
                //monitoreoBotellas(numeroOrden);
                //monitoreoCajas(numeroOrden);
                //indicadorCantCajas(numeroOrden, modelo[i][""CajasPlanificadas""]);
                //indicadorCantBotellas(numeroOrden, modelo[i][""BotellasPlanificadas""]);
                //indicadorVelocidadBotellas(numeroOrden);
                //indicadorVelocidad");
            WriteLiteral("Cajas(numeroOrden);\r\n                //indicadoresVelocidad(numeroOrden); no se usa de momento\r\n                //break;\r\n            //}\r\n        //}\r\n    }\r\n    setInterval(actualizarTablasMonitoreo, 30000);\r\n</script>\r\n\r\n");
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
