import { SafeEmbedPipe } from './safe-embed.pipe';

describe('SafeEmbedPipe', () => {
  it('create an instance', () => {
    const pipe = new SafeEmbedPipe();
    expect(pipe).toBeTruthy();
  });
});
