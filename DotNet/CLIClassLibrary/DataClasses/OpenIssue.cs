/*************************************************
Initially Generated by SSoT.me - 2017
    EJ Alexandra - ssotme odxml42/odxml-to-csharp-pocos
    This file WILL NOT be overwritten once changes are made.
*************************************************/
using System;
using System.ComponentModel;
                        
namespace EAPI.CLI.Lib.DataClasses
{                   
    
    public partial class OpenIssue 
    {
        public OpenIssue()
        {
            this.InitPoco();
        }

        public override String ToString()
        {
            return String.Format("OpenIssue: {0}", this.Name);
        }
                            
    }
}