# Api_HPlusSportSolution


an actual learning practice from linkedlearning-Christian Wenz, 

advanced web api, .net 6 course implementation .. 


 contains:


developing from empty templates:


-->controllers/


	//simple method/route test, gets a string when run


-->models/


	products.cs/
	categories.cs/
		properties/
		relations/


-->packages manager/


	entityframworkcore// for object relational mapping
	entityframworkcore.inmemory// to be dependant of server


-->models/


	shopcontext.cs/
		dbcontext// interitance by entityframeworkcore
		ctor//as injection of dbcontextoptions
		dbset//
		onmodelcreating//modelbuilder to define relation between categories and products
	extensionsformodelbuilder.cs/
			//data to seed is defined here
	shopcontext.cs/
			modelbuilder.seed//data from extension


-->Program.cs/


		/add service.adddbcontext/
		.UseInMemoryDatabase("Shop")//to not to need for database
		.EnableSensitiveDataLogging()//to check seeding error in detail


-->productcontroller.cs/


		ctor()/
			_context/
			_context.database.ensurecreated()//ensure seeding
		getallproducts()//return a list of products ienumerable (an alt could be return action result-below)
						//.toarray, converts to json by auto
		getallproducts()//returning a list of products by aciton result
		getoneproduct()//returning one item-product
			return NotFound()//unexisting id is requested, if null
		async action-ing//cahnge method signature, add async Task, await, toArrayAsync 
		async Post/
			CreateAtAction//post a product by provided argument is product it self(not id fx)
						//additions to supercede nullable issue for Category

-->in scenario


				/where description is required but missing, gets default value instead of 400 error
	program.cs/
			addcontrollers().configureapibehaviour()//suppressmodelstateinvalidfilter..
	async post method/
			badrequest//return if error message is desired
			//if not modelstate.isvalid//guarantees getting error message

-->update data/put method


			//dont miss.. update requires id for put request and in the body (postman)
			//updateing comes with some issues to handle
			//lack of id, failed save, already cahnged product etc
			
			
	program.cs/
	
	
			remove suppressmodelinvalidfilter//was previously added
			idCheck/
			productCheck/
			saveAsyncTry/
			DbUpdateConcurrancyExceptionCatch/

-->delete data/


		by id//find by id and remove and save cahnges!
		multiple delete//not httpPost with RouteDelete is used
						/DeleteRange is used
						//sample query on Postman-->POST:https://localhost:7175/api/products/delete?ids=1&ids=10


-->paginating the result

//is to be able to ask result in certain page(s).. show some, not all of it!
			queryParameters.cs/
					//means page and page size defined
					
					
			productscontroller.cs/GetAllProducts()
					/gather products under an IQueryableList
					/skip() to hopp over pages until asked page
					/take() to take only asked page
					//sample query on postman--> GET:https://localhost:7175/api/products?size=4
					//sample query on postman--> GET:https://localhost:7175/api/products?size=4&page=3


-->filtering the result//limit with ruleset


				/parameter class
				/where clause
				/controller.. getallproducts/update parameter
				/controller.. getallproducts/wherecheck to filter parameters
				//sample query on postman--> GET:https://localhost:7175/api/products?maxprice=70
				//sample query on postman--> GET:https://localhost:7175/api/products?maxprice=70&minprice=50
				
				
-->searching the result/
				
				
				/productqueryparameters.cs//add search parameters
				/controller/getallproducts()/where check to search parameters
				//sample query on postman--> GET:https://localhost:7175/api/products?minprice=30&sku=summer
				//sample query on postman--> GET:https://localhost:7175/api/products?sku=summer&name=ty
				
				
-->sorting the result/
				
				
				/iquaryableextension class with asc/desc code is created//hardcoding here!
				/lambda expression to set criteria.//Lambda expressions in C# are used like anonymous functions, 
													with the difference that in Lambda expressions you don't need to 
													specify the type of the value that you input thus making it more 
													flexible to use. The '=>' is the lambda operator which is used 
													in all lambda expressions.
													
													
				/sorting properties added to queryparameters.cs
				//sample query on postman--> GET:https://localhost:7175/api/products?sortby=Price&sortOrder=desc
				//above, price is capital to match with property name
				/searchterm property and code added for global insensitive search
				//sample query on postman--> GET:https://localhost:7175/api/products?searchTerm=vb
				
				
-->versioning/
		
		
		/install nuget package for microsoft.aspnetcore.mvc.versioning
			//using url
				program.cs/service.add versioning
				controller.cs//versioning decorations//[Route("v{v:apiVersion}/products")]
							//renaming controller class for versioning
							//sample query postman-->GET:https://localhost:7175/v2.0/products
		
		
		//using http header
			program.cs/services.add api version reader//define how version naming is//new HeaderApiVersionReader("X-API-Version")
			controller/versioning decoration//[Route("products")]
				//sample query for VERSION 1 postman-->GET:https://localhost:7175/products
				//sample query for VERSION 2 postman-->
						//GET:https://localhost:7175/products + (go header key+value menu, provide:) X-API-Version 2.0
		
		
		//using query string
			program.cs/cancel-comment new headerapi reader
			postman/deselect header key value menu
			postman/query for api-version=2.0
			//sample query for VERSION 2 postman--> GET:https://localhost:7175/products?api-version=2.0
			program.cs//optional//query string version in header versioning, line24
			//https://localhost:7175/products?qst-api-version=2.0
	
	
	/swagger glitch// to fix swagger
			nuget/versioning.apiexplorer
			program.cs/add service addversionedapiexplorer// with options


-->securing api & web app of it/
		
		
		/https redirection
		/hsts//use on production, strict/enforcing https (for client use)
				//web app
		/cors//protection for javascript codes manipulate server
				/[EnableCors]//per controller
				/[DisableCors()] 
			/program.cs//cors enable with a policy !!
		/core identity//adding to existing project
				/install code generator
				/add new scaffold item/add identity/all//so comes login etc security tools!!!
		/token based authentication/
		/OAUTH 2.0/
		/identity server/
