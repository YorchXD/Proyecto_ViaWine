#pragma checksum "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6da1395e4825bb21140b84a2894fc8daf8f6424d"
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
#line 1 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion;

#line default
#line hidden
#line 2 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\_ViewImports.cshtml"
using ViaWines_Automatizacion.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6da1395e4825bb21140b84a2894fc8daf8f6424d", @"/Views/Proceso/Proceso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ebb1dcc86c43848c37b3a8e4cbfd888a4913ed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Proceso_Proceso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViaWines_Automatizacion.Models.Orden>>
    {
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
#line 3 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
  
    ViewData["Title"] = "Detalle del Problema";


#line default
#line hidden
            BeginContext(118, 184, true);
            WriteLiteral("\r\n\r\n\r\n<section class=\"content-header\">\r\n    <div class=\"\">\r\n        <h1>\r\n            Proceso\r\n            <small>del pedido</small>\r\n        </h1>\r\n    </div>\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 18 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
         using (Html.BeginForm("Proceso", "Proceso", FormMethod.Post, new { @style = "border:none" }))
        {

#line default
#line hidden
            BeginContext(417, 566, true);
            WriteLiteral(@"            <div class=""col-xs-12 col-md-6"">
                <div class=""input-group date "">
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
#line 31 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
        }

#line default
#line hidden
            BeginContext(994, 156, true);
            WriteLiteral("\r\n\r\n        <div class=\"col-xs-12 col-md-6\">\r\n            <select class=\"form-control select2\" id=\"numeroOrden\" onchange=\"mostrarOrden()\">\r\n                ");
            EndContext();
            BeginContext(1150, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6da1395e4825bb21140b84a2894fc8daf8f6424d5575", async() => {
                BeginContext(1176, 20, true);
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1205, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 38 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#line 40 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                     foreach (var item in Model)
                    {
                        

#line default
#line hidden
#line 42 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                         if (item.Estado == 1)
                        {

#line default
#line hidden
            BeginContext(1413, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1441, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6da1395e4825bb21140b84a2894fc8daf8f6424d8384", async() => {
                BeginContext(1490, 21, false);
#line 44 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                                                                       Write(item.OrdenFabricacion);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 44 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
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
            BeginContext(1520, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 45 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1606, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1634, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6da1395e4825bb21140b84a2894fc8daf8f6424d11269", async() => {
                BeginContext(1674, 21, false);
#line 48 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                                                              Write(item.OrdenFabricacion);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
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
            BeginContext(1704, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 49 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                        }

#line default
#line hidden
#line 49 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                         
                    }

#line default
#line hidden
#line 50 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                     
                }

#line default
#line hidden
            BeginContext(1775, 11317, true);
            WriteLiteral(@"            </select>
        </div>
    </div>
        
</section>

<section class=""content"">
    <div class=""row"">
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box"">
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
            <div class=""small-box"">
                <div class=""inner"">
                    <br>
                    <h3>53<sup style=""font-size: 20px"">%</sup></h3>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-stats-bars""></i>
                </div>
                <p class=""small-box-footer""> Botel");
            WriteLiteral(@"las finalizadas</p>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box"">
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
            <div class=""small-box"">
                <div class=""inner"">
                    <br>
                    <h3>65</h3>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-pie-graph""></i>
                </div>
                <p class=""small-box-footer"">Cantidad de botella por minuto</p>
            </div>
        </div");
            WriteLiteral(@">
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
                <button type=""button"" class=""btn btn-block bg-purple"" data-toggle=""modal"" data-target=""#modal-inicio"">Inicio</button>
            </p>
            <p>
                <button type=""button"" class=""btn btn-block bg-orange"" data-toggle=""modal"" data-target=""#modal-pausar"">Pausar</button>
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
                  ");
            WriteLiteral(@"  <h3 class=""box-title"">Descripción de la orden</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
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

                    </dl>
         ");
            WriteLiteral(@"       </div>
                <!-- /.box-body -->
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
                            <td>2");
            WriteLiteral(@".</td>
                            <td>8:40</td>
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
  ");
            WriteLiteral(@"              </div>
            </div>
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
                          ");
            WriteLiteral(@"  <td>9:01</td>
                        </tr>
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
                <div class=""modal-heade");
            WriteLiteral(@"r bg-purple"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <h4 class=""modal-title"">Iniciar el proceso de producción</h4>
                </div>
                <div class=""modal-body"">
                    <p>¿Seguro que desea inicializar el proceso de producción?</p>
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


    <div class=""modal fade"" id=""modal-pausar"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div cl");
            WriteLiteral(@"ass=""modal-header bg-orange"">
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



    <div class=""modal fade"" id=""modal-finalizar"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-olive"">");
            WriteLiteral(@"
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
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
</section>



<script>
    function mostrarOrden()
    {
        var ordenSelect = document.getElementById(""numeroOrden"");
        var optionSelected = ordenSelect.options[orden");
            WriteLiteral("Select.selectedIndex].value;\r\n\r\n        var modelo = ");
            EndContext();
            BeginContext(13093, 96, false);
#line 353 "C:\Users\Administrador.WIN-I6PNSJ93H28\Desktop\Proyecto_ViaWine\Software\Aplicacion\ViaWines_Automatizacion\ViaWines_Automatizacion\Views\Proceso\Proceso.cshtml"
                Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model,Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
            EndContext();
            BeginContext(13189, 941, true);
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
            }
        }
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
