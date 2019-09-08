using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _008_TaskSchedulers
{
    public partial class Main : Form
    {
        private readonly TaskScheduler m_syncContextTaskScheduler;
        private CancellationTokenSource m_cts;
        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                Console.WriteLine(sum);
               // Thread.Sleep(20);
                // The following line throws OperationCanceledException when Cancel
                // is called on the CancellationTokenSource referred to by the token
                if (ct.IsCancellationRequested)
                {
                    return sum;
                }
                checked { sum += n; } // if n is large, this will throw System.OverflowException
            }
            return sum;
        }
        public Main()
        {    // Get a reference to a synchronization context task scheduler
            m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Text = "Synchronization Context Task Scheduler Demo";
            Visible = true; Width = 600; Height = 100;
            InitializeComponent();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (m_cts != null)
            { // An operation is in flight, cancel it
                m_cts.Cancel();
                m_cts = null;
            }
            else
            { // An operation is not in flight, start it
                Text = "Operation running";
                m_cts = new CancellationTokenSource();
                // This task uses the default task scheduler and executes on a thread pool thread
                Task<Int32> t = Task.Run(() => Sum(m_cts.Token, 20000), m_cts.Token);
                // These tasks use the sync context task scheduler and execute on the GUI thread
                t.ContinueWith(task => Text = "Result: " + task.Result,
        CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
        m_syncContextTaskScheduler);
                t.ContinueWith(task => Text = "Operation canceled",
                CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled,
                m_syncContextTaskScheduler);
                t.ContinueWith(task => Text = "Operation faulted",
                CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                m_syncContextTaskScheduler);
            }
            base.OnMouseClick(e);
        }
    }
}