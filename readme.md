## Links

* [graph-ql](http://fiyazhasan.me/graphql-with-asp-net-core/)
* [graphiql](https://github.com/graphql/graphiql)


## URL

```

POST https://localhost:44315/api/graphql 

```

### Request

```json

{
	"query": "{naveen steve}"
}

```

### Response

```json

{
	"data":
	{
	
		"naveen": "Hi, Naveen",
		
		"steve":"Hi, Steve"
	}
}

```