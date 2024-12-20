/** @type {import('next').NextConfig} */
const nextConfig = {
    reactStrictMode: false,
    images: {
        remotePatterns: [
            { hostname: "localhost" },
            { hostname: "media.mapgenie.io" },
            { hostname: "cdn.mapgenie.io" }
        ]
    }
}

module.exports = nextConfig
