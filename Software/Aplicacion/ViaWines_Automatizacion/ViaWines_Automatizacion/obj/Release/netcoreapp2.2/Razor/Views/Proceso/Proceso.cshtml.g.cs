#pragma checksum "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c33bbe4a54a365855341a585a0d89ff85336af4e"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c33bbe4a54a365855341a585a0d89ff85336af4e", @"/Views/Proceso/Proceso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Proceso_Proceso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViaWines_Automatizacion.Models.Orden>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "null", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
  
    ViewData["Title"] = "Detalle del Problema";


#line default
#line hidden
            BeginContext(118, 184, true);
            WriteLiteral("\r\n\r\n\r\n<section class=\"content-header\">\r\n    <div class=\"\">\r\n        <h1>\r\n            Proceso\r\n            <small>del pedido</small>\r\n        </h1>\r\n    </div>\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 18 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
         using (Html.BeginForm("Proceso", "Proceso", FormMethod.Post, new { @style = "border:none" }))
        {

#line default
#line hidden
            BeginContext(417, 590, true);
            WriteLiteral(@"            <div class=""col-xs-12 col-md-6"">
                <div class=""input-group date "">
                    <div class=""input-group-addon"">
                        <i class=""fa fa-calendar""></i>
                    </div>
                    <input type=""text"" class=""form-control pull-right"" id=""datepicker"" name=""fecha"" onload=""obtenerFecha()"">
                    <div class=""input-group-btn"">
                        <button type=""submit"" class=""btn btn-default""><i class=""fa fa-search""></i></button>
                    </div>
                </div>
            </div>
");
            EndContext();
#line 31 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
        }

#line default
#line hidden
            BeginContext(1018, 156, true);
            WriteLiteral("\r\n\r\n        <div class=\"col-xs-12 col-md-6\">\r\n            <select class=\"form-control select2\" id=\"numeroOrden\" onchange=\"mostrarOrden()\">\r\n                ");
            EndContext();
            BeginContext(1174, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c33bbe4a54a365855341a585a0d89ff85336af4e5710", async() => {
                BeginContext(1213, 20, true);
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
            BeginContext(1242, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 38 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#line 40 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                     foreach (var item in Model)
                    {
                        

#line default
#line hidden
#line 42 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                         if (item.Estado == 1)
                        {

#line default
#line hidden
            BeginContext(1450, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1478, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c33bbe4a54a365855341a585a0d89ff85336af4e8627", async() => {
                BeginContext(1527, 21, false);
#line 44 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                                                                       Write(item.OrdenFabricacion);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 44 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
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
            BeginContext(1557, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 45 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1643, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1671, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c33bbe4a54a365855341a585a0d89ff85336af4e11419", async() => {
                BeginContext(1711, 21, false);
#line 48 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                                                              Write(item.OrdenFabricacion);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 48 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
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
            BeginContext(1741, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 49 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                        }

#line default
#line hidden
#line 49 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                         
                    }

#line default
#line hidden
#line 50 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                     
                }

#line default
#line hidden
            BeginContext(1812, 14207, true);
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
            WriteLiteral(@"              <span class=""info-box-icon""><i class=""fa fa-bookmark-o""></i></span>

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
            WriteLiteral(@"        <span class=""info-box-number"">120</span>
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
                <button type=""button"" class=""btn btn-");
            WriteLiteral(@"block bg-purple"" onclick=""exist_proces_ini()"">Inicio</button>
            </p>
            <p>
                <button type=""button"" class=""btn btn-block bg-orange"" data-toggle=""modal"" data-target=""#modal-pausar"">Pausar</button>
            </p>
            <p>
                <button type=""button"" class=""btn btn-block bg-maroon"" data-toggle=""modal"" data-target=""#modal-posponer"">Posponer</button>
            </p>
            <p>
                <button type=""button"" class=""btn btn-block bg-olive"" data-toggle=""modal"" data-target=""#modal-finalizar"">Terminar</button>
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
            WriteLiteral(@"                    <dl class=""dl-horizontal"">
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
            </div");
            WriteLiteral(@">
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
                            <td>8:40</td>
                  ");
            WriteLiteral(@"          <td>8:46</td>
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
            </div>
            <!-- /.box -->
            WriteLiteral(@"
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
                        </tr>
                     ");
            WriteLiteral(@"   <tr>
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
                    <button type=""button"" class=""close");
            WriteLiteral(@""" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"" id=""title-ini-process"">Iniciar el proceso de producción</h4>
                </div>
                <div class=""modal-body"">
                    <p id=""body-ini-process"">¿Seguro que desea inicializar el proceso de producción?</p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" class=""btn bg-black"" onclick=""IniciarProceso()"">Aceptar</button>
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
                <div");
            WriteLiteral(@" class=""modal-header bg-orange"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"">Proceso en pausa</h4>
                </div>
                <div class=""modal-body"">
                    <p>One fine body&hellip;</p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" class=""btn bg-black"">Aceptar</button>
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
                <div class=""modal-header bg-maroon"">");
            WriteLiteral(@"
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"">Posponer el proceso</h4>
                </div>
                <div class=""modal-body"">
                    <p>One fine body&hellip;</p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" class=""btn bg-black"">Aceptar</button>
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
                    <button");
            WriteLiteral(@" type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"">Finalizar proceso</h4>
                </div>
                <div class=""modal-body"">
                    <p>¿Está seguro de finalizar el proceso de producción?</p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default pull-left"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" class=""btn bg-black"">Aceptar</button>
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
                    <button ");
            WriteLiteral(@"type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"">Falló iniciar proceso</h4>
                </div>
                <div class=""modal-body"">
                    <p>No se puede iniciar proceso dado que existe otro ejecutandose</p>
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


<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script>
$(document).ready(function () {
    var modelo = ");
            EndContext();
            BeginContext(16020, 96, false);
#line 412 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
            Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model,Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(16116, 903, true);
            WriteLiteral(@";
    var fecha = (modelo[0][""FechaFabricacion""]).split('T')[0];
    $(""#datepicker"").datepicker({ format: 'yyyy-mm-dd' }).val(fecha);
});
</script>

<script>
function IniciarProceso() {
    var fecha = $(""#datepicker"").val();
    var orden = $(""#numeroOrden"").val();
    var datos = {
        Orden: orden,
        Estado: 1,
        Fecha: fecha
    };
    $.ajax(
        {
            url: '/Proceso/Proceso',
            data: datos,
            dataType: 'json; charset=utf-8',
            type: 'POST',
            success: function (data)
            {
                alert('Success');
            },
        });
    $('#modal-inicio').modal('hide');
}

</script>
<script>
function mostrarOrden()
{
    var ordenSelect = document.getElementById(""numeroOrden"");
    var optionSelected = ordenSelect.options[ordenSelect.selectedIndex].value;

    var modelo = ");
            EndContext();
            BeginContext(17020, 96, false);
#line 448 "D:\Repositorios\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
            Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model,Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(17116, 1572, true);
            WriteLiteral(@";

    for (var i = 0; i < modelo.length; i++)
    {
        if (modelo[i][""OrdenFabricacion""] == optionSelected)
        {
            document.getElementById(""SKU"").innerHTML = modelo[i][""SKU""];
            document.getElementById(""descripcionProducto"").innerHTML = modelo[i][""Descripcion""];
            document.getElementById(""cantCajasPlan"").innerHTML = modelo[i][""CajasPlanificadas""];
            document.getElementById(""cantBotellasPlan"").innerHTML = modelo[i][""BotellasPlanificadas""];
            document.getElementById(""horaInicioPlan"").innerHTML = (modelo[i][""HoraInicioPlanificada""]).split('T')[1];
            document.getElementById(""horaTerminoPlan"").innerHTML = (modelo[i][""HoraTerminoPlanificada""]).split('T')[1];
            document.getElementById(""fechaPlan"").innerHTML = (modelo[i][""FechaFabricacion""]).split('T')[0];
            document.getElementById(""estado"").innerHTML = modelo[i][""Estado""];
        }
    }
    }
</script>

<script>
    function exist_proces_ini()
    {
   ");
            WriteLiteral(@"     $.ajax
        (
            {
                url: '/Proceso/Exit_proces_ini',
                data: {},
                dataType: 'json; charset=utf-8',
                type: 'POST',
                    success: function (data) {
                        $('#title-ini-process').
                        $(""#modal-inicio"").modal(""show"");
                    },
                    error: function () {
                        $(""#modal-alerta"").modal(""show"");
                    },
            }
        );
    }
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