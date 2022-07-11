const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require("process");

const context = [
    "/weatherforecast", "/bff", "/remote", "/signin-oidc", "/signout-callback-oidc"
];

//const target = 'https://localhost:6004';

const target = env.ASPNETCORE_HTTPS_PORT
    ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
    : env.ASPNETCORE_URLS
    ? env.ASPNETCORE_URLS.split(";")[0]
    : "http://localhost:18084";


console.log(target);
//console.log(target2);


module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: target,
        secure: false
    });

    app.use(appProxy);
};
