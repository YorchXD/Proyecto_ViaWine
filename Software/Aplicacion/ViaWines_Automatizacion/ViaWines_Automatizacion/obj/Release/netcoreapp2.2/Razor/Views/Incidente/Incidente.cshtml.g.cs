#pragma checksum "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Incidente\Incidente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incidente_Incidente), @"mvc.1.0.view", @"/Views/Incidente/Incidente.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Incidente/Incidente.cshtml", typeof(AspNetCore.Views_Incidente_Incidente))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d27a81cbeb2859b5eb3bd696e53e19fd3385c0b3", @"/Views/Incidente/Incidente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Incidente_Incidente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViaWines_Automatizacion.Models.Orden>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/../../../img/cargando1.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("opacity:0.8; width:40%; height:30%; margin-top: 30%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "null", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/incidente.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Incidente\Incidente.cshtml"
  
    ViewData["Title"] = "Problemas en el proceso de producción";

#line default
#line hidden
            BeginContext(133, 2281, true);
            WriteLiteral(@"
<section class=""content-header"">
    <div class="" row col-xs-12"">
        <h1>
            Incidentes
            <small>Del día</small>
        </h1>
    </div>

    <div class=""row"">
        <div class=""form-group col-md-6 col-xs-12"">
            <div class=""datepicker"">
                <div class=""input-group date"">
                    <div class=""input-group-addon"">
                        <i class=""fa fa-calendar""></i>
                    </div>
                    <input type=""text"" class=""form-control pull-right"" id=""datepicker"" name=""fecha"" autocomplete=""off"" onchange=""obtenerOPI()"">
                </div>
            </div>
        </div>


        <div class=""col-xs-12 col-md-6"">
            <p>
                <button type=""button"" class=""btn btn-block bg-green"" data-toggle=""modal"" id=""btnAgregarIncidencia"">Agregar incidente</button>
            </p>
        </div>
    </div>
</section>



<!-- Main content -->
<section class=""content"">
    <div class=""row"">
    ");
            WriteLiteral(@"    <div class=""col-xs-12"">
            <div class=""box"">
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""OPI"" class=""table table-bordered display dt-responsive"" cellpadding=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th data-priority=""1"">Código corto</th>
                                <th class=""none"">Código largo</th>
                                <th>Tiempo</th>
                                <th>Clasificación</th>
                                <th class=""none"">Aclaración</th>
                                <th>Zona</th>
                                <th data-priority=""1"">Cant. Incidentes</th>
                                <th data-priority=""1"">Acción</th>
                            </tr>
                        </thead>

                    </table>
                </div>
                <!-- /.box-body -->
            </div>
            <!-");
            WriteLiteral("- /.box -->\r\n        </div>\r\n        <!-- /.col -->\r\n    </div>\r\n    <!-- /.row -->\r\n\r\n    <div id=\"myModal\" class=\"modalFP\" style=\"display: none;\">\r\n        <!-- Modal content -->\r\n        <div class=\"modal-contentFP\">\r\n            ");
            EndContext();
            BeginContext(2414, 103, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b38665", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2517, 710, true);
            WriteLiteral(@"
        </div>
    </div>

    <div class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"" id=""modal-agregar-incidencia"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div id=""modal-header-incicente"" class=""modal-header bg-green"">
                    <h4 class=""modal-title"" id=""title-incidencia"">Ingreso de incidencia</h4>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                        <select class=""form-control select2"" style=""width: 100%;"" id=""opcionIncidencia"" onchange=""tipoIngresoIncidencia()"">
                            ");
            EndContext();
            BeginContext(3227, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b310659", async() => {
                BeginContext(3254, 30, true);
                WriteLiteral("Ingresar incidencia por código");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3293, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(3323, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b312401", async() => {
                BeginContext(3341, 34, true);
                WriteLiteral("Ingresar incidencia por formulario");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3384, 456, true);
            WriteLiteral(@"
                        </select>
                    </div>

                    <!---------------------------incidencia por codigo---------------------------------->
                    <div class=""form-group col-lg-12 col-md-12 col-sm-12 col-xs-12"" id=""codigoIncidenciadiv"">
                        <select class=""form-control select2"" style=""width: 100%;"" id=""codigoIncidencia"" onchange=""mostrarIncidenciaCodigo()"">
                            ");
            EndContext();
            BeginContext(3840, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b314274", async() => {
                BeginContext(3877, 37, true);
                WriteLiteral("Seleccione el código de la incidencia");
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3923, 1928, true);
            WriteLiteral(@"
                        </select>
                    </div>

                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"" id=""descripcionIncidente1"">
                        <div class=""box box-solid"">
                            <div class=""box-header with-border"">
                                <i class=""fa fa-text-width""></i>
                                <h3 class=""box-title"">Detalle de la incidencia</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class=""box-body"">
                                <dl class=""dl-horizontal"">
                                    <dt>Tipo de tiempo</dt>
                                    <dd id=""nombreAgrupacionTiempo1"">-</dd>
                                    <dt>Clasificación</dt>
                                    <dd id=""descripcionClasificacion1"">-</dd>
                                    <dt>Aclaración</dt>
                                    <dd id=""aclaraci");
            WriteLiteral(@"onClasificacion1"">-</dd>
                                    <dt>Nombre zona</dt>
                                    <dd id=""nombreZona1"">-</dd>
                                </dl>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- ./col -->
                    <!---------------------------fin incidencia por codigo---------------------------------->
                    <!---------------------------incidencia por formulario---------------------------------->
                    <div class=""form-group col-lg-6 col-md-6 col-sm-12 col-xs-12"" id=""tiempodiv"">
                        <select class=""form-control select2"" style=""width: 100%;"" id=""tiempo"" onchange=""iniciarSelectClasificacionIncidencia()"">
                            ");
            EndContext();
            BeginContext(5851, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b318301", async() => {
                BeginContext(5890, 28, true);
                WriteLiteral("Seleccione el tipo de tiempo");
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5927, 340, true);
            WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""form-group col-lg-6 col-md-6 col-sm-12 col-xs-12"" id=""clasificaciondiv"">
                        <select class=""form-control select2"" style=""width: 100%;"" id=""clasificacion"" onchange=""mostrarIncidenciaCodigo1()"">
                            ");
            EndContext();
            BeginContext(6267, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b320674", async() => {
                BeginContext(6306, 27, true);
                WriteLiteral("Seleccione la clasificación");
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6342, 4558, true);
            WriteLiteral(@"
                        </select>
                    </div>

                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"" id=""descripcionIncidente2"">
                        <div class=""box box-solid"">
                            <div class=""box-header with-border"">
                                <i class=""fa fa-text-width""></i>
                                <h3 class=""box-title"">Detalle de la incidencia</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class=""box-body"">
                                <dl class=""dl-horizontal"">
                                    <dt>Aclaración</dt>
                                    <dd id=""aclaracionClasificacion2"">-</dd>
                                    <dt>Nombre zona</dt>
                                    <dd id=""nombreZona2"">-</dd>
                                </dl>
                            </div>
                            <!-- /.box-body -->
    ");
            WriteLiteral(@"                    </div>
                        <!-- /.box -->
                    </div>
                    <!-- ./col -->
                    <!---------------------------fin incidencia por formulario---------------------------------->

                    <div class=""form-group col-lg-12 col-md-12 col-sm-12 col-xs-12"" id=""observaciondiv"">
                        <input class=""form-control"" type=""text"" placeholder=""Ingrese una observación clara de la falla..."" id=""observacion"">
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" id=""btnConfirmarIncidencia"" class=""btn bg-black"">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <div class=""modal fade"" id=""modal-c");
            WriteLiteral(@"onfirm"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div id=""modal-header-confirm"" class=""modal-header bg-green"">
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
</section>
<!-- /.content -->





    

<style>
    .fechaIncidente a {
        background-color: #560f3d !important;");
            WriteLiteral(@"
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
        background: url(""~/../../../img/tenor.gif"") no-repeat;
        background-color: rgba(254,254,254,0.4);
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 340px;
        height: 340px;
        text-align: center;
        border-radius: 30px;
        position: absolute;
        top: 50%;
        left: 50%;
        t");
            WriteLiteral(@"ransform: translate(-50%, -50%);
    }
</style>

<!--script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script-->
<script src=""https://unpkg.com/moment""></script>
<!--   Datatables-->
<script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.10.20/datatables.min.js""></script>
<!-- extension responsive -->
<script src=""https://cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js""></script>
");
            EndContext();
            BeginContext(10900, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27a81cbeb2859b5eb3bd696e53e19fd3385c0b327480", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(10941, 1393, true);
            WriteLiteral(@"
<script>
    $.extend($.fn.dataTable.defaults, {
        'destroy': true,
        'responsive': true,
        'dom': ""Bfrtip"",
        'searching': false,
        'ordering': true,
        'info': false,
        'autoWidth': true,
        'paging': true,
        'scrollX': false,
        'lengthChange': false,
        'processing': true,
        'iDisplayLength': 10,
        'language': {
            ""decimal"": """",
            ""emptyTable"": ""No hay información"",
            ""info"": ""Mostrando _START_ a _END_ de _TOTAL_ Entradas"",
            ""infoEmpty"": ""Mostrando 0 to 0 of 0 Entradas"",
            ""infoFiltered"": ""(Filtrado de _MAX_ total entradas)"",
            ""infoPostFix"": """",
            ""thousands"": "","",
            ""lengthMenu"": ""Mostrar _MENU_ Entradas"",
            ""loadingRecords"": ""Cargando..."",
            ""processing"": ""Procesando..."",
            ""search"": ""Buscar:"",
            ""zeroRecords"": ""Sin resultados encontrados"",
            ""paginate"": {
               ");
            WriteLiteral(@" ""first"": ""Primero"",
                ""last"": ""Ultimo"",
                ""next"": ""Siguiente"",
                ""previous"": ""Anterior""
            }
        }
    });
    $(document).ready(function () {
        $.fn.DataTable.ext.pager.numbers_length = 4;
        ObtenerFechaIncidentes();
        obtenerOPI();
        obtenerInicidencias();
    });
</script>");
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
