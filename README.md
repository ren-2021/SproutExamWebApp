# SproutExamWebApp

Test Question:
If we are going to deploy this on production, what do you think is the next
improvement that you will prioritize next? This can be a feature, a tech debt, or
an architectural design.

Answer:
I think the best improvement to be prioritize next is the error logging. It will help a lot in terms of debugging and also in developing new features.
We can make a table that handles logging of all the errors that will be catched by the system.

# Before Starting the app #
-----------------------
ToDo:

Database:
Run all the Scripts:
https://github.com/ren-2021/SproutExamDatabase

Run: 
npm install

If you encounter an client error:
- Remove node_modules
- Remove package-lock.json
- run npm install

If you encounter an error on depreciate setupMiddlewares
..\SproutExamWebApp\Sprout.Exam.WebApp\ClientApp\node_modules\react-scripts\config\webpackDevServer.config.js
Change this code:
onBeforeSetupMiddleware(devServer) {
    // Keep `evalSourceMapMiddleware`
    // middlewares before `redirectServedPath` otherwise will not have any effect
    // This lets us fetch source contents from webpack for the error overlay
    devServer.app.use(evalSourceMapMiddleware(devServer));

    if (fs.existsSync(paths.proxySetup)) {
    // This registers user provided middleware for proxy reasons
    require(paths.proxySetup)(devServer.app);
    }
},
onAfterSetupMiddleware(devServer) {
    // Redirect to `PUBLIC_URL` or `homepage` from `package.json` if url not match
    devServer.app.use(redirectServedPath(paths.publicUrlOrPath));

    // This service worker file is effectively a 'no-op' that will reset any
    // previous service worker registered for the same host:port combination.
    // We do this in development to avoid hitting the production cache if
    // it used the same host and port.
    // https://github.com/facebook/create-react-app/issues/2272#issuecomment-302832432
    devServer.app.use(noopServiceWorkerMiddleware(paths.publicUrlOrPath));
},

to
setupMiddlewares: (middlewares, devServer) => {
    if (!devServer) {
        throw new Error('webpack-dev-server is not defined')
    }

    if (fs.existsSync(paths.proxySetup)) {
        require(paths.proxySetup)(devServer.app)
    }

    middlewares.push(
        evalSourceMapMiddleware(devServer),
        redirectServedPath(paths.publicUrlOrPath),
        noopServiceWorkerMiddleware(paths.publicUrlOrPath)
    )

    return middlewares;
},


