namespace WpfApplication1.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Speech.Synthesis;
    using System.Speech.AudioFormat;

    using WpfApplication1.BoilerPlate;
    using WpfApplication1.Model;

    /// <summary>
    /// The stream data.
    /// </summary>
    public class StreamData : ObservableObject
    {
        /// <summary>
        /// The file paths.
        /// </summary>
        //private readonly ObservableCollection<string> filePaths = StreamSource.FilePath;

        /// <summary>
        /// The file path
        /// </summary>
        private string filePath;

        /// <summary>
        /// The file record.
        /// </summary>
        private string fileRecord;

        /// <summary>
        /// The file record word.
        /// </summary>
        private string fileRecordWord;

        /// <summary>
        /// The file record count.
        /// </summary>
        private int fileRecordCount;

        /// <summary>
        /// The file name.
        /// </summary>
        private string fileName;

        /// <summary>
        /// The read speed pause.
        /// Two-way binding with the in-code property and the XAML permits a default value of 100 on app. launch
        /// </summary>
        private int readSpeedPause = 100;

        /// <summary>
        /// Initialise Speech
        /// </summary>
        private SpeechSynthesizer speech = new SpeechSynthesizer();
       

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamData"/> class.
        /// Now Obsolete - but used the Model::StreamSource as filepaths source (along with the TESTDATA docs)
        /// </summary>
        public StreamData()
        {
        }
 

        /// <summary>
        /// Gets or sets the stream file source.
        /// </summary>
        public string StreamFileSource
        {
            get
            {   
                if (this.filePath != null)
                {
                    this.ReadFileStreamData();
                }

                return this.filePath;
            }

            set
            {
                if (this.filePath != value)
                {
                    this.filePath = value;
                    this.RaisePropertyChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets the stream record.
        /// </summary>
        public string StreamRecord
        {
            get
            {
                return this.fileRecord;
            }

            private set
            {
                if (this.fileRecord != value)
                {
                    this.fileRecord = value;
                    this.RaisePropertyChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets the stream record word.
        /// </summary>
        public string StreamRecordWord
        {
            get
            {
                return this.fileRecordWord;
            }

            private set
            {
                if (this.fileRecordWord != value)
                {
                    this.fileRecordWord = value;
                    this.RaisePropertyChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets the stream record count.
        /// </summary>
        public int StreamRecordCount
        {
            get
            {
                return this.fileRecordCount;
            }

            private set
            {
                if (this.fileRecordCount != value)
                {
                    this.fileRecordCount = value;
                    this.RaisePropertyChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets the stream source file name.
        /// </summary>
        public string StreamSourceFileName
        {
            get
            {
                return this.fileName;
            }

            private set
            {
                if (this.fileName != value)
                {
                    this.fileName = value;
                    this.RaisePropertyChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets the stream read speed pause.
        /// </summary>
        public int StreamReadSpeedPause
        {
            get
            {
                return this.readSpeedPause;
            }

            private set
            {
                if (this.readSpeedPause != value)
                {
                    this.readSpeedPause = value;
                    this.RaisePropertyChangedEvent();
                }
            }
        }

        /// <summary>
        /// The read file stream data.
        /// </summary>
        public void ReadFileStreamData()
        {
            try
            {
                var fs = new FileStream(this.filePath, FileMode.Open);
                using (var sr = new StreamReader(fs, Encoding.ASCII))
                {
                    string record;
                    int recordCounter = 0;
                    
                    // Find installed voices ..
                    var voices = speech.GetInstalledVoices();
                    foreach (var voice in voices)
                    {
                        if (voice.Enabled)
                        {
                            speech.SelectVoice(voice.VoiceInfo.Name);
                        }
                    }
                    speech.Volume = 100;

                    string path = this.filePath; // Access to foreach variable in TaskFactory.StartNew {closure} has potentially anomalous behaviour - copy to local variable ..
                    while ((record = sr.ReadLine()) != null)
                    {
                        string recordCopy = record; // TaskFactory has problem working with 'record' but no problem with a 'record copy' (!?)

                        Task.Factory.StartNew
                        (() =>
                        {
                            // Could do something here ..
                        }
                        ).ContinueWith((t) =>
                            {
                                // Set property bound to WPF control ..
                                if (path != null)
                                {
                                    this.StreamSourceFileName = path;
                                }

                                // Set property bound to WPF control ..
                                this.StreamRecord = recordCopy;

                                // Set property bound to WPF control ..
                                recordCounter++;
                                this.StreamRecordCount = recordCounter;

                                // Read ...
                                speech.Rate = -10 + (this.StreamReadSpeedPause % 20); // rate has range of -10 to 10
                                speech.Speak(recordCopy);

                                // Pause between each record ...
                                Thread.Sleep(this.StreamReadSpeedPause);
                            }
                        );

                        Task.Factory.StartNew
                        (() =>
                            {
                                // Could do something here ..
                            }
                        ).ContinueWith((t) =>
                            {
                                // Set property bound for WPF display ..
                                var recordWords = recordCopy.Split(' ');
                                foreach (var recordWord in recordWords)
                                {
                                    this.StreamRecordWord = recordWord;
                                    
                                    // Pause between each word ...
                                    Thread.Sleep(this.StreamReadSpeedPause);
                                }
                            }
                        );

                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                this.StreamRecord = "FILE NOT FOUND";
            }
            catch (Exception)
            {
                this.StreamRecord = "SOMETHING REALLY WENT WRONG";
            }
            finally
            {
            }
        }
    }
}
