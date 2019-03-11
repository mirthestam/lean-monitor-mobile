using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanMobile.Data.Remote.Responses;

namespace LeanMobile.Data.Utils
{
    public static class RootResponseExt
    {
        public static void EnsureSuccess(this RootResponse response)
        {
            if (!response.Success)
            {
                throw new Exception(response.Errors.First());
            }
        }
    }
}
