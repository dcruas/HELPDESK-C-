﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Properties {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DAL.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT  DT_ABERTURA, SUM(CASE WHEN CD_STATUS &lt;= 2 THEN 1 ELSE 0 END) AS Pendentes,
        ///	   SUM(CASE WHEN CD_STATUS &lt;= 2 AND getdate() &gt; DT_ABERTURA THEN 1 ELSE 0 END) AS Atrasados,	   
        ///	   SUM(CASE WHEN CD_STATUS = 3 THEN 1 ELSE 0 END) AS &apos;Encerradoc/Atraso&apos;,	   
        ///	   SUM(CASE WHEN CD_STATUS &gt;= 3 THEN 1 ELSE 0 END) AS TotalEncerrados,
        ///	   AVG(CD_AVALIACAO) As Media 
        ///FROM TB_CHAMADO WHERE DT_ABERTURA between @dti and @dtf group by DT_ABERTURA.
        /// </summary>
        internal static string RelatorioDetalhadoChamados {
            get {
                return ResourceManager.GetString("RelatorioDetalhadoChamados", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT SUM(CASE WHEN CD_STATUS &lt;= 2 THEN 1 ELSE 0 END) AS Pendentes,
        ///	   SUM(CASE WHEN CD_STATUS &lt;= 2 AND getdate() &gt; DT_ABERTURA THEN 1 ELSE 0 END) AS Atrasados,	   
        ///	   SUM(CASE WHEN CD_STATUS = 3 THEN 1 ELSE 0 END) AS &apos;Encerradoc/Atraso&apos;,	   
        ///	   SUM(CASE WHEN CD_STATUS &gt;= 3 THEN 1 ELSE 0 END) AS TotalEncerrados,
        ///	   AVG(CD_AVALIACAO) As Media 	   
        ///
        ///FROM TB_CHAMADO WHERE DT_ABERTURA between @dti and @dtf.
        /// </summary>
        internal static string RelatorioGeralChamados {
            get {
                return ResourceManager.GetString("RelatorioGeralChamados", resourceCulture);
            }
        }
    }
}
