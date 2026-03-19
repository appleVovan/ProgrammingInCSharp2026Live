using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.Samples
{
    internal class MyBackgroudWorker
    {
        private Tuple<string, int, double> _inputParams;
        private Tuple<string, bool> _outputParams;

        private CancellationToken _token;
        public Tuple<string, bool> OutputParams => _outputParams;

        public MyBackgroudWorker(string param1, int param2, double param3, CancellationToken token)
        {
            _inputParams = new Tuple<string, int, double>(param1, param2, param3);
            _token = token;
        }

        internal void Process()
        {
            var inputParams = _inputParams;
            //Process inputParams
            while (!_token.IsCancellationRequested)
            {
                if (!GetNextTask())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (_token.IsCancellationRequested)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                    continue;
                }
                //Perform Step1
                if (_token.IsCancellationRequested)
                {
                    //End processing on before step2
                    break;
                }
                //Perform Step2
                if (_token.IsCancellationRequested)
                {
                    //End processing on before step3
                    break;
                }
                //Perform Step3
            }
            _outputParams = new Tuple<string, bool>("Result", true);
        }

        private bool GetNextTask()
        {
               return true;
        }
    }
}
