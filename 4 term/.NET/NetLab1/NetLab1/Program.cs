using NetLab1;
using NetLab1.Infrastructure;

var context = DataGenerator.Generate();
var personService = new PersonService(context);
new IOManager(personService).Process();