﻿using System;


namespace TuVotoCuenta.Domain
{
    public class AddReportRequest : HttpRequestBase
    {
        public RecordItem RecordItem
        {
            get;
            set;
        }

    }
}
