#pragma checksum "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6853d27c3e0922eaded9aecaf72877932530d0ee"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6853d27c3e0922eaded9aecaf72877932530d0ee", @"/Views/Proceso/Proceso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Proceso_Proceso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViaWines_Automatizacion.Models.Orden>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "null", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(445, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6853d27c3e0922eaded9aecaf72877932530d0ee5240", async() => {
                BeginContext(484, 20, true);
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
            BeginContext(513, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 22 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#line 24 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                     foreach (var item in Model)
                    {
                        

#line default
#line hidden
#line 26 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                         if (item.Estado == 1)
                        {

#line default
#line hidden
            BeginContext(721, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(749, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6853d27c3e0922eaded9aecaf72877932530d0ee8153", async() => {
                BeginContext(798, 21, false);
#line 28 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                                                                       Write(item.OrdenFabricacion);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 28 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                               WriteLiteral(item.OrdenFabricacion);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(828, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 29 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(914, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(942, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6853d27c3e0922eaded9aecaf72877932530d0ee10941", async() => {
                BeginContext(982, 21, false);
#line 32 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                                                              Write(item.OrdenFabricacion);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 32 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                               WriteLiteral(item.OrdenFabricacion);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1012, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 33 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                        }

#line default
#line hidden
#line 33 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                         
                    }

#line default
#line hidden
#line 34 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                     
                }

#line default
#line hidden
            BeginContext(1083, 14131, true);
            WriteLiteral(@"            </select>
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
                    <span class=""info-box-number"">900</span>

                    <div class=""progress"">
                        <div class=""progress-bar"" style=""width: 70%""></div>
                    </div>
                    <span class=""progress-description"">
                        70% de avance
                    </span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- ./col -->

        <div class=""col-md-3 col-sm-6 col-xs-12"">
            <div class=""info-box bg-gray"">
    ");
            WriteLiteral(@"            <span class=""info-box-icon""><i class=""fa fa-bookmark-o""></i></span>

                <div class=""info-box-content"">
                    <span class=""info-box-text"">Cajas finalizadas</span>
                    <span class=""info-box-number"">150</span>

                    <div class=""progress"">
                        <div class=""progress-bar"" style=""width: 70%""></div>
                    </div>
                    <span class=""progress-description"">
                        70% de avance
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
                    <span class=""info-box-text"">Cantidad de botella por minuto</span>
              ");
            WriteLiteral(@"      <span class=""info-box-number"">120</span>
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
                    <span class=""info-box-number"">20</span>
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
        <div class=""col-lg-3 col-md-4 col-sm-4 col-xs-6"">
            <p>
                <button type=""button"" id=""btnInicio"" cl");
            WriteLiteral(@"ass=""btn btn-block bg-purple"" >Inicio</button>
            </p>
            <p>
                <button type=""button"" id=""btnPausar"" class=""btn btn-block bg-orange"" data-toggle=""modal"" data-target=""#modal-pausar"">Pausar</button>
            </p>
            <p>
                <button type=""button"" id=""btnPosponer"" class=""btn btn-block bg-maroon"" data-toggle=""modal"" data-target=""#modal-posponer"">Posponer</button>
            </p>
            <p>
                <button type=""button"" id=""btnFinalizar"" class=""btn btn-block bg-olive"" data-toggle=""modal"" data-target=""#modal-finalizar"">Terminar</button>
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
     ");
            WriteLiteral(@"           <div class=""box-body"">
                    <dl class=""dl-horizontal"">
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
                <!-");
            WriteLiteral(@"- /.box-body -->
            </div>
            <!-- /.box -->
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
                    <table class=""table table-bordered"">
                        <tr>
                            <th style=""width: 10px"">#</th>
                            <th>Hora de inicio</th>
                            <th>Hora de término</th>
                        </tr>
                        <tr>
                            <td>1.</td>
                            <td>8:40</td>
                            <td>8:45</td>
                        </tr>
                        <tr>
                            <td>2.</td>
                          ");
            WriteLiteral(@"  <td>8:40</td>
                            <td>8:46</td>
                        </tr>
                        <tr>
                            <td>3.</td>
                            <td>8:41</td>
                            <td>8:46</td>
                        </tr>
                        <tr>
                            <td>4.</td>
                            <td>8:41</td>
                            <td>8:46</td>
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
            ");
            WriteLiteral(@"</div>
            <!-- /.box -->
        </div>
        <!-- /.col -->

        <div class=""col-md-6"">
            <div class=""box"">
                <div class=""box-header with-border"">
                    <h3 class=""box-title"">Monitoreo de cajas</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table class=""table table-bordered"">
                        <tr>
                            <th style=""width: 10px"">#</th>
                            <th>Hora de finalización</th>
                        </tr>
                        <tr>
                            <td>1.</td>
                            <td>9:00</td>
                        </tr>
                        <tr>
                            <td>2.</td>
                            <td>9:00</td>
                        </tr>
                        <tr>
                            <td>3.</td>
                            <td>9:01</td>
                 ");
            WriteLiteral(@"       </tr>
                        <tr>
                            <td>4.</td>
                            <td>9:01</td>
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
            <!-- /.box -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->

    <div class=""modal fade"" id=""modal-inicio"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-purple"">
                   ");
            WriteLiteral(@" <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
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
                    <bu");
            WriteLiteral(@"tton type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
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
                    <");
            WriteLiteral(@"button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
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
           ");
            WriteLiteral(@"         <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
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
                <div class=""modal-header bg-purple"">
");
            WriteLiteral(@"                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
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
");
            EndContext();
            BeginContext(15214, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6853d27c3e0922eaded9aecaf72877932530d0ee28730", async() => {
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
            BeginContext(15276, 68, true);
            WriteLiteral("\r\n<script>\r\n    function seleccionarOrden() {\r\n        var modelo = ");
            EndContext();
            BeginContext(15345, 97, false);
#line 396 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model, Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(15442, 721, true);
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
    $(document).ready(function () {

        var modelo = ");
            EndContext();
            BeginContext(16164, 96, false);
#line 417 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model,Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(16260, 1652, true);
            WriteLiteral(@";

        for (var i = 0; i < modelo.length; i++)
        {
            if (modelo[i][""Estado""] == 1)
            {
                document.getElementById(""SKU"").innerHTML = modelo[i][""SKU""];
                document.getElementById(""descripcionProducto"").innerHTML = modelo[i][""Descripcion""];
                document.getElementById(""cantCajasPlan"").innerHTML = modelo[i][""CajasPlanificadas""];
                document.getElementById(""cantBotellasPlan"").innerHTML = modelo[i][""BotellasPlanificadas""];
                document.getElementById(""horaInicioPlan"").innerHTML = modelo[i][""HoraInicioPlanificada""];
                document.getElementById(""horaTerminoPlan"").innerHTML = modelo[i][""HoraTerminoPlanificada""];
                document.getElementById(""fechaPlan"").innerHTML = (modelo[i][""FechaFabricacion""]).split('T')[0];
                switch (modelo[i][""Estado""]) {
                    case 0:
                        document.getElementById(""estado"").innerHTML = 'No iniciada';
                   ");
            WriteLiteral(@"     break;
                    case 1:
                        document.getElementById(""estado"").innerHTML = 'Iniciada';
                        break;
                    case 2:
                        document.getElementById(""estado"").innerHTML = 'Pausada';
                        break;
                    case 3:
                        document.getElementById(""estado"").innerHTML = 'Pospuesta';
                        break;
                    default:
                        document.getElementById(""estado"").innerHTML = 'Finalizada';
                }

            }
        }

    })
</script>
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
